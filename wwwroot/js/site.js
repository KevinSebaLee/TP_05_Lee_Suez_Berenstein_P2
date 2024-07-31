// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const video = document.getElementById('Anuncio');
const videoId = 'Anuncio';
const watchedKey = `${videoId}_watched`;
const progressKey = `${videoId}_progress`;
const watchedIntervalsKey = `${videoId}_watched_intervals`;
const intervalDuration = 5; // duration of each interval in seconds

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

// Restore playback progress and initialize watched intervals
video.addEventListener('loadedmetadata', () => {
    const savedProgress = sessionStorage.getItem(progressKey);
    if (savedProgress) {
        video.currentTime = parseFloat(savedProgress);
    }

    // Initialize watched intervals
    const totalIntervals = Math.ceil(video.duration / intervalDuration);
    let watchedIntervals = new Array(totalIntervals).fill(false);
    sessionStorage.setItem(watchedIntervalsKey, JSON.stringify(watchedIntervals));
});

// Track playback progress and watched intervals
video.addEventListener('timeupdate', () => {
    const currentTime = video.currentTime;
    sessionStorage.setItem(progressKey, currentTime);

    // Mark the current interval as watched
    const totalIntervals = Math.ceil(video.duration / intervalDuration);
    const currentInterval = Math.floor(currentTime / intervalDuration);
    let watchedIntervals = JSON.parse(sessionStorage.getItem(watchedIntervalsKey));
    watchedIntervals[currentInterval] = true;
    sessionStorage.setItem(watchedIntervalsKey, JSON.stringify(watchedIntervals));
});

// Check if the video has ended
video.addEventListener('ended', () => {
    let watchedIntervals = JSON.parse(sessionStorage.getItem(watchedIntervalsKey));
    const allWatched = watchedIntervals.every(interval => interval);
    if (allWatched) {
        alert('You have watched the video completely in this session!');
    } else {
        alert('Please watch the full video without skipping to get the extra life.');
    }
});