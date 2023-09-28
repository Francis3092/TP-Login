document.addEventListener("DOMContentLoaded", function () {
    const loginForm = document.getElementById("login-form");

    loginForm.addEventListener("submit", function (e) {
        e.preventDefault();

        const username = document.getElementById("username").value;
        const password = document.getElementById("password").value;


        if (!isValidPassword(password)) {
            showErrorAlert("La contraseña debe tener al menos 8 caracteres, una letra en mayúscula y un carácter especial.");
            return;
        }


        if (simulatedLogin(username, password)) {
            showSuccessAlert("Inicio de sesión exitoso. ¡Bienvenido!");
        } else {
            showErrorAlert("Inicio de sesión fallido. Verifica tus credenciales.");
        }
    });

    function isValidPassword(password) {
        const minLength = 8;
        const uppercaseRegex = /[A-Z]/;
        const specialCharRegex = /[!@#$%^&*()_+{}\[\]:;<>,.?~\\-]/;

        return (
            password.length >= minLength &&
            uppercaseRegex.test(password) &&
            specialCharRegex.test(password)
        );
    }

    function showErrorAlert(message) {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: message,
            confirmButtonColor: '#d33',
            confirmButtonText: 'OK'
        });
    }

    function showSuccessAlert(message) {
        Swal.fire({
            icon: 'success',
            title: 'Éxito',
            text: message,
            confirmButtonColor: '#28a745',
            confirmButtonText: 'OK'
        });
    }


    function simulatedLogin(username, password) {

        return true;
    }
});