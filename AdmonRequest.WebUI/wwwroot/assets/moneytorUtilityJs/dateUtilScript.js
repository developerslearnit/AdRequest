function checkIsDateWeekEnd(data) {
    var response = 0;
    try {
        var d = new Date(data);
        var day = d.getDay();
        if (d.toString().toLowerCase() === "invalid date" || d.toString().toLowerCase() === "nan") {
            response = -1;
        } else {
            if (d.getDay() == 6 || d.getDay() == 0) {
                response = 1;
            }
        }
    } catch (ex) {
        response = -2;
    }
    return response;
};

function MoveSettlementDateFromWeekend(data, transactionType)
{
    debugger;
    var sat = 0;
    var sun = 0;
    switch (transactionType)
    {
        case "B":
            sat = 2; sun = 2;
            break;
        case "E":
            sat = 2; sun = 2;
            break;
    }
    var response = new Date();
    switch (checkIsDateWeekEnd(data).toString()) {
        case "1":
            var _date = new Date(data);
            switch (_date.getDay().toString()) {
                case "6":
                    response.setDate(_date.getDate() + Number(sat));
                    break;
                case "0":
                    response.setDate(_date.getDate() + Number(sun));
                    break;
            }
            break;
        default:
            response = data;
            break;

    }
    return response;
}
function moveDateToNextWorkingDate(data)
{
    var response = new Date();
    switch (checkIsDateWeekEnd(data).toString())
    {
        case "1":
            var _date = new Date(data);
            switch (_date.getDay().toString())
            {
                case "6":
                    _date.setDate(_date.getDate() + 2);
                    break;
                case "0":
                    _date.setDate(_date.getDate() + 1);
                    break;
            }
            break;
        default:
            response = data;
            break;
        
    }
    return response;
}
function addDaysToDate(date,days)
{
    debugger;
    var response = new Date();
    var _date = new Date(date);
    if (_date.toString().toLowerCase() === "invalid date" || Number(days).toString() === "NaN") {
        return date;
    }
    else
    {
       // response = new Date(_date);
        return _date.setDate(_date.getDate() + Number(days) * 1);
    }
}
function getDayOfWeekString(date)
{
    var dayOfWeek = ["Sunday", "Monday", "Tuesday", "Wednessday", "Thursday", "Friday", "Saturday"];
    var _date = new Date(date);
    if (_date.toString().toLowerCase() === "invalid date" || number(days).toString() === "NaN") {
        return "Invalid_Date";
    }
    return dayOfWeek[_date.getDay()];

}
function getTodaysDate()
{
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; 
    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd;
    }
    if (mm < 10) {
        mm = '0' + mm;
    }
    return today = mm + '/' + dd + '/' + yyyy;
}
function parseMicrosoftDate(date)
{
    var res = new Date(parseInt(date.substr(6)));
    return res
}
function globalErrorLogic(xhr)
{
    var msg = "An Error has occured, please try again";
    switch (xhr.status) {
        case 0:
            msg = 'Not connect. Verify Network Connection is active';
            break;
        case 404:
            msg = 'Resources You are Requesting for Can not be found';
            break;
        case 500:
            msg = 'The Server Return an Error, Please Contact System Administrator';
            break;
        case "timeout":
            msg = 'Your Request has timeout, Please Try Again';
            break;
        case "abort":
            msg = 'Your Request has been aborted, Please Contact System Administrator';
            break;
    }
    return msg;
}
