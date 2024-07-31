// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let tiempo = parseInt(localStorage.getItem('tiempo')) || 2400;
                    
let timer = setInterval(function() {
    let minutes = Math.floor(tiempo / 60);
    let seconds = tiempo % 60;
    document.getElementById('tiempo').innerText = `${minutes}:${seconds < 10 ? '0' : ''}${seconds}`;

    // Save the current timer state to localStorage
    localStorage.setItem('tiempo', tiempo);

    if (tiempo <= 0) {
        clearInterval(timer);
        location.href = 'Perdio';
        // Reset timer in localStorage when the game is lost
        localStorage.removeItem('tiempo'); // This effectively resets the timer for a new game
    }
    tiempo--;
}, 1000); // Changed interval to 1000ms (1 second) for accuracy