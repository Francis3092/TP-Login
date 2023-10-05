document.addEventListener("DOMContentLoaded", function () {
    const registrationForm = document.getElementById("registration-form");
    const passwordField = document.getElementById("Contraseña");
    const togglePasswordButton = document.getElementById("toggle-password");

    togglePasswordButton.addEventListener("click", function () {
        const type = passwordField.getAttribute("type") === "password" ? "text" : "password";
        passwordField.setAttribute("type", type);
        togglePasswordButton.classList.toggle("fa-eye-slash");
        togglePasswordButton.classList.toggle("fa-eye");
    });   

    registrationForm.addEventListener("submit", function (e) {
        e.preventDefault();
    
        const username = document.getElementById("UserName").value; 
        const password = document.getElementById("Contraseña").value; 
        const confirmPassword = document.getElementById("confirm-password").value;
    
        if (password !== confirmPassword) {
            showErrorAlert("Las contraseñas no coinciden. Por favor, inténtalo de nuevo.");
            return;
        }
    
        if (!isValidPassword(password)) {
            showErrorAlert("La contraseña debe tener al menos 8 caracteres, una letra en mayúscula y un carácter especial.");
            return;
        }
    
        showSuccessAlert("¡Registro completado con éxito!");
    
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