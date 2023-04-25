var e = document.getElementById("elementSelected");

function onChange() {
    var value = e.value;

    if (value == "BankSlip") {
        $('#cardNumber').css("display", "none")
        $('#cardExpiration').css("display", "none")
        $('#cardCvv').css("display", "none")
    }
    else {
        $('#cardNumber').show();
        $('#cardExpiration').show();
        $('#cardCvv').show();
    }
}
e.onchange = onChange;
onChange();