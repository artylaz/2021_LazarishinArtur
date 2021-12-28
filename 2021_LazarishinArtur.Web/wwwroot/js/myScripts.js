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

    if (windowShape == "Прямоугольное") {
        if (widthWindow < 0 || widthWindow >= 5 || widthWindow == "") {
            document.getElementById("widthWindowVal").style.display = "block";
            return;
        }
        else if (heightWindow < 0 || heightWindow >= 5 || heightWindow == "") {
            document.getElementById("heightWindowVal").style.display = "block";
            return;
        }
    }
    else if (windowShape == "Круглое") {
        if (diameter < 0 || diameter >= 5 || diameter == "") {
            document.getElementById("diameterVal").style.display = "block";
            return;
        }
    }
    else if (windowShape == "Квадратное") {
        if (sideLength < 0 || sideLength >= 5 || sideLength == "") {
            document.getElementById("sideLengthVal").style.display = "block";
            return;
        }
    }



    if (tempBake < 0 || tempBake >= 4500 || tempBake == "") {
        document.getElementById("tempBakeVal").style.display = "block";
        return;
    }
    else if (wallThickness < 0 || wallThickness >= 5 || wallThickness == "") {
        document.getElementById("wallThicknessVal").style.display = "block";
        return;
    }
    else if (windowOpenTime < 0 || windowOpenTime == "") {
        document.getElementById("windowOpenTimeVal").style.display = "block";
        return;
    }

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


function HideBlock(el) {
    document.getElementById("result").style.display = "none";

    if (el.id == "widthWindow") {
        document.getElementById("widthWindowVal").style.display = "none";

    }
    else if (el.id == "heightWindow") {
        document.getElementById("heightWindowVal").style.display = "none";

    }
    else if (el.id == "diameter") {
        document.getElementById("diameterVal").style.display = "none";

    }
    else if (el.id == "sideLength") {
        document.getElementById("sideLengthVal").style.display = "none";

    }
    else if (el.id == "tempBake") {
        document.getElementById("tempBakeVal").style.display = "none";

    }
    else if (el.id == "wallThickness") {
        document.getElementById("wallThicknessVal").style.display = "none";

    }
    else if (el.id == "windowOpenTime") {
        document.getElementById("windowOpenTimeVal").style.display = "none";

    }
}

function OpenResult() {
    document.getElementById("result").style.display = "grid";

}

hubConnection.start();

