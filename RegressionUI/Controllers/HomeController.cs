using System;
using System.Web.Mvc;
using RegressionBusiness;
using System.Linq;
using DiffMatchPatch;
using RegressionEntities;

namespace RegressionUI.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public Int32 PageSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PageSize"]);

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SaveMap(string pMapName)
        {
            try
            {
                Regression regression = new Regression();
                regression.MapName = pMapName;
                regression.StartDate = DateTime.Today;
                regression.StatusId = 1;
                regression.UserId = UserID;

                bool success = new RegressionManager().Add(regression);

                return Json(success = true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult GetMapData(int currentPage)
        {
            try
            {
                Int32 pTotalRecords = 0;

                var data = new RegressionManager().GetRegressionListByUserID(UserID, PageSize, currentPage, out pTotalRecords).ToList();

                TempData["CurrentPage"] = currentPage;
                TempData["TotalRecords"] = pTotalRecords;

                var recordsFound = data.Select(u =>
                    new
                    {
                        u.Id,
                        u.MapName,
                        u.StartDateString,
                        u.EndDateString,
                        u.RegressionStatus
                    });


                return Json(recordsFound, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetPager()
        {
            try
            {
                int count = TempData["TotalRecords"] == null ? 1 : (int)TempData["TotalRecords"];

                int PageSize = Convert.ToInt32(@System.Configuration.ConfigurationManager.AppSettings["PageSize"]);

                int tot_pages = count / PageSize;
                int remainder = count % PageSize;

                if (remainder > 0)
                    tot_pages += 1;

                string pager = string.Empty;

                if (tot_pages > 1)
                {
                    for (int cnt = 1; cnt <= tot_pages; cnt++)
                    {
                        if ((TempData["CurrentPage"] != null) && (cnt == (int)TempData["CurrentPage"]))
                            pager = pager + "<li class='active'><span>" + cnt + "</span></li>";
                        else
                            pager = pager + "<li><a href='#' onclick='getData(" + cnt + ")'>" + cnt + "</a></li>";
                    }
                }

                return Json(pager, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetRegressionAspTpDetails(int regressionID)
        {
            try
            {
                var data = new RegressionAspTpManager().GetRegressionAspTpDetails(regressionID).ToList();

                var recordsFound = data.Select(u =>
                    new
                    {
                        u.Id,
                        u.Asp_tpCode,
                        u.Client,
                        u.Utility,
                        u.Matches,
                        u.Diff,
                        u.RegressionStatus
                    });

                return Json(recordsFound, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetFileInfo(int aspTpID)
        {
            try
            {
                var data = new RegressionFileManager().GetRegressionFileDetails(aspTpID).ToList();

                var recordsFound = data.Select(u =>
                    new
                    {
                        u.Id,
                        u.PreFileName,
                        u.PostFileName,
                        u.TransDateString,
                        u.RegressionStatus
                    });

                return Json(recordsFound, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Compare(int fileID)
        {
            var fileInfo = new RegressionFileManager().GetRegressionFileInfo(fileID);

            if (fileInfo != null)
            {
                string file_1 = fileInfo.PreFileName;
                string file_2 = fileInfo.PostFileName;

                file_1 = Common.Utilities.ReadFileContent(file_1);
                file_2 = Common.Utilities.ReadFileContent(file_2);

                var dmp = new diff_match_patch();
                var diffs = dmp.diff_main(file_1, file_2);
                var html = dmp.diff_prettyHtml(diffs);

                ComparisonOutput output = new ComparisonOutput();
                output.PreFileContent = file_1;
                output.FileDifference = html;

                return Json(output, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }

        public class ComparisonOutput
        {
            public string PreFileContent { get; set; }
            public string FileDifference { get; set; }
        }
    }
}