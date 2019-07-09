"use strict"

document.getElementById("submit").addEventListener("click", function () {
    Swal.disableButtons();
    Swal.fire({
        title: 'Tack!',
        text: 'Din låt är registrerad.',
        type: 'success',
        showConfirmButton: false,
    });
});