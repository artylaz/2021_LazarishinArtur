/*const { Modal } = require("./bootstrap.bundle");*/



OnSelectionChange(document.getElementById("windowShape"));




if (document.getElementById("id").value != "")
    document.getElementById("result").style.display = "grid";



const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/Hub")
    .build();

hubConnection.on("Receive", function (calculateVM) {



    for (var item of document.getElementsByTagName("input")) {
        if (item.getAttribute('id') == "apertureRatio")
            item.value = calculateVM.getApertureRatio;
        else if (item.getAttribute('id') == "radiationHeatLoss")
            item.value = calculateVM.getRadiationHeatLoss;
    };


});

function Edit(e) {

    let windowShape;
    let widthWindow;
    let heightWindow;
    let diameter;
    let sideLength;
    let tempBake;
    let wallThickness;
    let windowOpenTime;

    for (var item of document.getElementsByTagName("select")) {
        if (item.getAttribute('id') == "windowShape")
            windowShape = item.value;
    };

    for (var item of document.getElementsByTagName("input")) {
        if (item.getAttribute('id') == "widthWindow")
            widthWindow = item.value;
        else if (item.getAttribute('id') == "heightWindow")
            heightWindow = item.value;
        else if (item.getAttribute('id') == "diameter")
            diameter = item.value;
        else if (item.getAttribute('id') == "sideLength")
            sideLength = item.value;
        else if (item.getAttribute('id') == "tempBake")
            tempBake = item.value;
        else if (item.getAttribute('id') == "wallThickness")
            wallThickness = item.value;
        else if (item.getAttribute('id') == "windowOpenTime")
            windowOpenTime = item.value;

    };

    /*if (windowShape < 0 || windowShape >= 5)*/

    hubConnection.invoke("Send", {
        "WindowShape": windowShape,
        "WidthWindow": +widthWindow,
        "HeightWindow": +heightWindow,
        "Diameter": +diameter,
        "SideLength": +sideLength,
        "TempBake": +tempBake,
        "WallThickness": +wallThickness,
        "WindowOpenTime": +windowOpenTime
    });

    document.getElementById("result").style.display = "grid";

    e.preventDefault()

    const blockID = anchor.getAttribute('href')

    document.querySelector(blockID).scrollIntoView({
        behavior: 'smooth',
        block: 'start'
    })
}

function Val(el) {
    el.style.display = "flex";

}

function OnSelectionChange(select) {

    var valueSelect = select.value;

    if (valueSelect == "Прямоугольное") {
        document.getElementsByName("Rectangle").forEach(item => {
            item.style.display = "flex";
        });
        document.getElementsByName("Squared").forEach(item => {
            item.style.display = "none";
        });
        document.getElementsByName("Circle").forEach(item => {
            item.style.display = "none";
        });

    }
    else if (valueSelect == "Квадратное") {
        document.getElementsByName("Rectangle").forEach(item => {
            item.style.display = "none";
        });
        document.getElementsByName("Squared").forEach(item => {
            item.style.display = "flex";
        });
        document.getElementsByName("Circle").forEach(item => {
            item.style.display = "none";
        });
    }
    else if (valueSelect == "Круглое") {
        document.getElementsByName("Rectangle").forEach(item => {
            item.style.display = "none";
        });
        document.getElementsByName("Squared").forEach(item => {
            item.style.display = "none";
        });
        document.getElementsByName("Circle").forEach(item => {
            item.style.display = "flex";
        });

    }

    document.getElementById("result").style.display = "none";
}

function Save() {
    let id;
    let windowShape;
    let name;
    let widthWindow;
    let heightWindow;
    let diameter;
    let sideLength;
    let tempBake;
    let wallThickness;
    let windowOpenTime;

    for (var item of document.getElementsByTagName("select")) {
        if (item.getAttribute('id') == "windowShape")
            windowShape = item.value;
    };

    for (var item of document.getElementsByTagName("input")) {

        if (item.getAttribute('id') == "widthWindow")
            widthWindow = item.value;
        else if (item.getAttribute('id') == "id")
            id = item.value;
        else if (item.getAttribute('id') == "heightWindow")
            heightWindow = item.value;
        else if (item.getAttribute('id') == "diameter")
            diameter = item.value;
        else if (item.getAttribute('id') == "sideLength")
            sideLength = item.value;
        else if (item.getAttribute('id') == "tempBake")
            tempBake = item.value;
        else if (item.getAttribute('id') == "wallThickness")
            wallThickness = item.value;
        else if (item.getAttribute('id') == "windowOpenTime")
            windowOpenTime = item.value;
        else if (item.getAttribute('id') == "nameRas")
            name = item.value;
    };

    hubConnection.invoke("Save", {
        "Id": +id,
        "WindowShape": windowShape,
        "Name": name,
        "WidthWindow": +widthWindow,
        "HeightWindow": +heightWindow,
        "Diameter": +diameter,
        "SideLength": +sideLength,
        "TempBake": +tempBake,
        "WallThickness": +wallThickness,
        "WindowOpenTime": +windowOpenTime
    });
}
hubConnection.on("SaveCalculate", function (name) {
    alert("Расчёт " + name + " сохранён")
});


function HideBlock() {
    document.getElementById("result").style.display = "none";
}

function OpenResult() {
    document.getElementById("result").style.display = "grid";

}

hubConnection.start();

