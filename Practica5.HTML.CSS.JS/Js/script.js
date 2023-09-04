document.addEventListener("DOMContentLoaded", function () {
    const gameForm = document.getElementById("game-form");
    const scoreElement = document.getElementById("score");
    const highScoreElement = document.getElementById("high-score");
    const resultMessageElement = document.getElementById("result-message");

    let score = 0; 
    let highScore = 0;
    let targetNumber = Math.floor(Math.random() * 100) + 1;

    gameForm.addEventListener("submit", function (e) {
        e.preventDefault();
        const guessInput = document.getElementById("numero");
        const guess = parseInt(guessInput.value);

        if (isNaN(guess) || guess < 1 || guess > 100) {
            resultMessageElement.textContent = "Ingresa un número válido entre 1 y 100.";
        } else {
            const difference = Math.abs(guess - targetNumber);

            if (difference === 0) {
                resultMessageElement.textContent = `¡Adivinaste el número ${targetNumber}!`;
                score+=10;
                if (score > highScore) {
                    highScore = score;
                }
                highScoreElement.textContent = highScore;
                targetNumber = Math.floor(Math.random() * 100) + 1;
            } else {
                resultMessageElement.textContent = `Intento fallido. El número correcto está a ${difference} unidades de distancia.`;
                score--; 
                scoreElement.textContent = score;
            }

            guessInput.value = "";

            if (score === 0) {
                resultMessageElement.textContent = "¡Perdiste! Tu puntaje llegó a 0.";
            }
        }
    });
});
