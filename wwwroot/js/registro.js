document.addEventListener("DOMContentLoaded", function () {
    const registrationForm = document.getElementById("registration-form");
    const passwordField = document.getElementById("password");
    const togglePasswordButton = document.getElementById("toggle-password");

    togglePasswordButton.addEventListener("click", function () {
        const type = passwordField.getAttribute("type") === "password" ? "text" : "password";
        passwordField.setAttribute("type", type);
        togglePasswordButton.classList.toggle("fa-eye-slash");
        togglePasswordButton.classList.toggle("fa-eye");
    });

    function getPaginaInicioUrl() {
        return new Promise(function(resolve, reject) {
            var xhr = new XMLHttpRequest();
            xhr.onreadystatechange = function() {
                if (xhr.readyState === 4) {
                    if (xhr.status === 200) {
                        resolve(xhr.responseText);
                    } else {
                        reject(xhr.statusText);
                    }
                }
            };
            xhr.open("GET", "/Home/GetPaginaInicioUrl", true);
            xhr.send();
        });
    }    

    registrationForm.addEventListener("submit", function (e) {
        e.preventDefault();
    
        const username = document.getElementById("username").value;
        const password = passwordField.value;
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
    
        // Obtén la URL de la página de inicio y redirige después de mostrar la alerta
        getPaginaInicioUrl().then(function(url) {
            setTimeout(function () {
                window.location.href = url;
            }, 2000);
        }).catch(function(error) {
            console.error("Error al obtener la URL de la página de inicio:", error);
        });
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