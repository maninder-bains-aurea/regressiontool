$(document).ready(function () {
    $('#loader').hide();
    $("#viewList").click(function () {
        $('#loader').show();
        getData(1);
    });

    $("#btnGo").click(function () {
        $('#loader').show();
        var pMapName = $('#MapName').val();
        if (pMapName == "") {
            toastr["error"]('Map Name can not be left blank!');
            $('#MapName').focus();
            $('#loader').hide();
        }
        else {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '/Home/SaveMap',
                data: { 'pMapName': pMapName },
                success: function (result) {
                    $('#loader').hide();
                    if (result == true) {
                        toastr["success"]('Map Saved Successfully.');
                        $('#MapName').val(''); $('#MapName').focus();
                    }
                    else {
                        toastr["error"]('An Error has occured. Please try again.');
                        $('#MapName').focus();
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    toastr["error"]('An Error has occured. Please try again.');
                    $('#loader').hide();
                }
            });
        }
    });
});

function getData(pageNumber) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Home/GetMapData',
        data: { 'currentPage': pageNumber },
        success: function (result) {
            $('#loader').hide();
            if (result.length > 0) {
                $('#divParent').empty();
                $('#divParent').append("<tbody></tbody>");
                $('#divParent').append("<tr class='row success'><th class='col-lg-1'></th><th class='col-lg-1'>#</th><th colspan='2' class='col-lg-4'>Map Name</th><th class='col-lg-2'>Start Date</th><th class='col-lg-2'>End Date</th><th class='col-lg-2'>Status</th></tr>");
                for (var i = 0; i < result.length; i++) {
                    var status = result[i].RegressionStatus.toUpperCase();
                    if (status.includes("COMPLETED")) {
                        $('#divParent').append("<tr class='row success' id='c" + result[i].Id + "'>\
                                <td class='col-lg-1 text-center'><a href='#' class='glyphicon-plus' style='text-decoration: none' onclick='getDetails(" + result[i].Id + ")' id='anc_" + result[i].Id + "'></a></td>\
                                <td class='col-lg-1'>" + result[i].Id + "</td><td colspan='2' class='col-lg-4'>" + result[i].MapName + "</td><td class='col-lg-2'>" + result[i].StartDateString + "</td>\
                                <td class='col-lg-2'>" + result[i].EndDateString + "</td><td class='col-lg-2'>" + result[i].RegressionStatus + "</td></tr>");
                    }
                    else {
                        $('#divParent').append("<tr class='row success' id='c" + result[i].Id + "'>\
                                <td class='col-lg-1 text-center'><a href='#' style='text-decoration: none' onclick='getDetails(" + result[i].Id + ")' id='anc_" + result[i].Id + "'></a></td>\
                                <td class='col-lg-1'>" + result[i].Id + "</td><td colspan='2' class='col-lg-4'>" + result[i].MapName + "</td><td class='col-lg-2'>" + result[i].StartDateString + "</td>\
                                <td class='col-lg-2'>" + result[i].EndDateString + "</td><td class='col-lg-2'>" + result[i].RegressionStatus + "</td></tr>");
                    }
                    getPagingData();
                }
            }
            else {
                toastr["error"]('No records found.');
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            toastr["error"]('An Error has occured. Please try again.');
            $('#loader').hide();
        }
    });
}

function getPagingData() {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/Home/GetPager',
        data: null,
        success: function (result) {
            $('#pager').empty();
            $('#pager').append(result);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
}

function getDetails(detailsId) {
    $('#loader').show();
    var hasClass = $('#anc_' + detailsId).hasClass("glyphicon-plus");
    if (hasClass == true) {
        $('#anc_' + detailsId).addClass("glyphicon-minus");
        $('#anc_' + detailsId).removeClass("glyphicon-plus");
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Home/GetRegressionAspTpDetails',
            data: { 'regressionID': detailsId },
            success: function (result) {
                $('#loader').hide();
                if (result.length > 0) {
                    for (var i = 0; i < result.length; i++) {
                        $('#c' + detailsId).after("<tr class='pid" + detailsId + " row info' id='c1_" + result[i].Id + "'><td class='col-lg-1 text-center'><a href='#' class='glyphicon-plus' style='text-decoration: none' onclick='getFileInfo(" + result[i].Id + ")' id='anc_c1_" + result[i].Id + "'></a></td>\
                        <td class='col-lg-1'>" + result[i].Id + "</td>\
                        <td class='col-lg-2'>" + result[i].Asp_tpCode + "</td>\
                        <td class='col-lg-2'>" + result[i].Client + "</td>\
                        <td class='col-lg-2'>" + result[i].Utility + "</td>\
                        <td class='col-lg-2'>" + result[i].Matches + "</td>\
                        <td class='col-lg-2'>" + result[i].Diff + "</td></tr>");
                    }
                    $('#c' + detailsId).after("<tr class='pid" + detailsId + " row info'><th class='col-lg-1 text-center'></th><th class='col-lg-1'>#</th><th class='col-lg-2'>ASP_TP Code</th><th class='col-lg-2'>Client</th>\
                        <th class='col-lg-2'>Utility</th><th class='col-lg-2'>Matches</th><th class='col-lg-2'>Diff</th></tr>");
                }
                else {
                    toastr["error"]('No records found.');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                toastr["error"]('An Error has occured. Please try again.');
                $('#loader').hide();
            }
        });
    }
    else {
        $('#anc_' + detailsId).removeClass("glyphicon-minus");
        $('#anc_' + detailsId).addClass("glyphicon-plus");
        $('.pid' + detailsId).remove();
        $('#loader').hide();
    }
};

function getFileInfo(asptpId) {
    $('#loader').show();
    var hasClass = $('#anc_c1_' + asptpId).hasClass("glyphicon-plus");
    if (hasClass == true) {
        $('#anc_c1_' + asptpId).addClass("glyphicon-minus");
        $('#anc_c1_' + asptpId).removeClass("glyphicon-plus");
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Home/GetFileInfo',
            data: { 'aspTpID': asptpId },
            success: function (result) {
                $('#loader').hide();
                if (result.length > 0) {
                    for (var i = 0; i < result.length; i++) {
                        $('#c1_' + asptpId).after("<tr class='pid1" + asptpId + " row active' id='c2_" + result[i].Id + "'><td class='col-lg-1 text-center'><a href='#' class='glyphicon-plus' style='text-decoration: none' onclick='fileCompare(" + result[i].Id + ")' id='anc_c2_" + result[i].Id + "'></a></td>\
                        <td class='col-lg-1'>" + result[i].Id + "</td><td colspan='4' class='col-lg-5'>" + result[i].PreFileName + "</td><td class='col-lg-5'>" + result[i].TransDateString + "</td></tr>");
                    }
                    $('#c1_' + asptpId).after("<tr class='pid1" + asptpId + " row active'><th class='col-lg-1 text-center'></th><th class='col-lg-1'>#</th><th colspan='4' class='col-lg-5'>Pre File Name</th><th class='col-lg-5'>Translated Date</th></tr>");
                }
                else {
                    toastr["error"]('No records found.');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                toastr["error"]('An Error has occured. Please try again.');
                $('#loader').hide();
            }
        });
    }
    else {
        $('#anc_c1_' + asptpId).removeClass("glyphicon-minus");
        $('#anc_c1_' + asptpId).addClass("glyphicon-plus");
        $('.pid1' + asptpId).remove();
        $('#loader').hide();
    }
};

function fileCompare(fileID) {
    $('#loader').show();
    var hasClass = $('#anc_c2_' + fileID).hasClass("glyphicon-plus");
    if (hasClass == true) {
        $('#anc_c2_' + fileID).addClass("glyphicon-minus");
        $('#anc_c2_' + fileID).removeClass("glyphicon-plus");
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Home/Compare',
            data: { 'fileID': fileID },
            success: function (result) {
                $('#loader').hide();
                $('#c2_' + fileID).after("<tr class='pid2" + fileID + " row'><th colspan='4'>File Content</th><th colspan='3'>Differences</th></tr>\
                <tr class='pid2" + fileID + " row'><td colspan='4'>" + result.PreFileContent + "</td><td colspan='3'>" + result.FileDifference + "</td></tr>");
                $('#loader').hide();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                toastr["error"]('An Error has occured. Please try again.');
                $('#loader').hide();
            }
        });
    }
    else {
        $('#anc_c2_' + fileID).removeClass("glyphicon-minus");
        $('#anc_c2_' + fileID).addClass("glyphicon-plus");
        $('.pid2' + fileID).remove();
        $('#loader').hide();
    }
};