document.addEventListener("DOMContentLoaded", function () {
    document.getElementById('firstName').addEventListener('input', function () {
        var firstName = this.value;
        if (!/^[A-Za-z]+$/.test(firstName)) {
            this.setCustomValidity("Ingresa solo letras, sin espacios ni caracteres especiales");
        } else {
            this.setCustomValidity("");
        }
    });

    document.getElementById('lastName').addEventListener('input', function () {
        var lastName = this.value;
        if (!/^[A-Za-z]+$/.test(lastName)) {
            this.setCustomValidity("Ingresa solo letras, sin espacios ni caracteres especiales");
        } else {
            this.setCustomValidity("");
        }
    });

    document.getElementById('title').addEventListener('input', function () {
        var title = this.value;
        if (!/^[A-Za-z]+$/.test(title)) {
            this.setCustomValidity("Ingresa solo letras, sin espacios ni caracteres especiales");
        } else {
            this.setCustomValidity("");
        }
    });
});