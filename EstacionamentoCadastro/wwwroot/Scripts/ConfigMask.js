$(document).ready(function () {
    Mask();
});

function Mask() {
    var options = {
        translation: {
            'Z': {
                pattern: /[0-9]/, optional: true
            }
        }
    };
    $('.IP').mask('0ZZ.0ZZ.0ZZ.0ZZ', options);
    $(".numerico").mask('99999999');

    $(".decimal").maskMoney({
        thousands: '',
        decimal: ',',
        //affixesStay: false,
        precision: 2,
        allowZero: true
    });

    $(".decimalNegative").maskMoney({
        thousands: '',
        decimal: ',',
        //affixesStay: false,
        precision: 2,
        allowZero: true,
        allowNegative: true
    });
}