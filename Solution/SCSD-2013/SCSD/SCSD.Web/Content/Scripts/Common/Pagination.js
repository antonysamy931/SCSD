
var CallBack;
function loadPagination(CallBackFunctionName) {
    CallBack = CallBackFunctionName;
}
function PageSizeChange(size) {   
    CallBack(1);
}

function FirstPage(firstPage) {
    CallBack(firstPage);
}

function LastPage(lastPage) {
    CallBack(lastPage);
}

function PreviousPage(prePage) {
    CallBack(prePage);
}

function NextPage(nextPage) {
    CallBack(nextPage);
}

function Page(pageNo) {
    CallBack(pageNo);
}