document.addEventListener("DOMContentLoaded", function () {
    const forgotPasswordForm = document.getElementById("forgot-password-form");

    forgotPasswordForm.addEventListener("submit", function (e) {
        e.preventDefault();

        const email = document.getElementById("email").value;


        showSuccessAlert("¡Recuperación de contraseña completada con éxito!");
    });

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
