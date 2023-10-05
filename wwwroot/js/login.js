document.addEventListener("DOMContentLoaded", function () {
    const loginForm = document.getElementById("login-form");
    const passwordField = document.getElementById("Contraseña"); // Cambiado a "Contraseña"
    const togglePasswordButton = document.getElementById("toggle-password");

    togglePasswordButton.addEventListener("click", function () {
        const type = passwordField.getAttribute("type") === "password" ? "text" : "password";
        passwordField.setAttribute("type", type);
        togglePasswordButton.classList.toggle("fa-eye-slash");
        togglePasswordButton.classList.toggle("fa-eye");
    });

    loginForm.addEventListener("submit", function (e) {
        e.preventDefault();

        const username = document.getElementById("UserName").value; // Cambiado a "UserName"
        const password = passwordField.value;

        if (!isValidPassword(password)) {
            showErrorAlert("La contraseña debe tener al menos 8 caracteres, una letra en mayúscula y un carácter especial.");
            return;
        }

        // Elimina la función simulatedLogin y utiliza la redirección directa
        showSuccessAlert("Inicio de sesión exitoso. ¡Bienvenido!");
        setTimeout(function () {
            window.location.href = '/Home/PaginaInicio'; // Ruta de acción directa
        }, 2000);
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
});