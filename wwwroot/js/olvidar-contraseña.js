document.addEventListener("DOMContentLoaded", function () {
    const forgotPasswordForm = document.getElementById("forgot-password-form");

    forgotPasswordForm.addEventListener("submit", function (e) {
        e.preventDefault();

        const email = document.getElementById("email").value;
        const securityQuestion = document.getElementById("security-question").value;
        const securityAnswer = document.getElementById("security-answer").value;

        if (isValidRecoveryData(email, securityQuestion, securityAnswer)) {
            const recoveredPassword = recoverPassword(email);
            showSuccessAlert(`¡Recuperación de contraseña completada con éxito!\nTu contraseña es: ${recoveredPassword}`);
        } else {
            showErrorAlert("Los datos de recuperación no son válidos. Verifica tu correo y respuesta.");
        }
    });

    function isValidRecoveryData(email, securityQuestion, securityAnswer) {
        // Implementa la lógica de validación aquí
        return true; // Simulación: siempre considera los datos como válidos
    }

    function recoverPassword(email) {
        // Implementa la lógica para recuperar la contraseña aquí
        return "contraseña_recuperada"; // Simulación: devuelve una contraseña ficticia
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

    function showErrorAlert(message) {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: message,
            confirmButtonColor: '#d33',
            confirmButtonText: 'OK'
        });
    }
});
