document.addEventListener("DOMContentLoaded", function () {
  const gameForm = document.getElementById("game-form");
  const scoreElement = document.getElementById("score");
  const highScoreElement = document.getElementById("high-score");
  const resultMessageElement = document.getElementById("result-message");
  const resetButton = document.getElementById("reset-button");
  const hintButton = document.getElementById("hint-button");

  let score = 0;
  let highScore = 0;
  let targetNumber = Math.floor(Math.random() * 20) + 1;

  gameForm.addEventListener("submit", function (e) {
    e.preventDefault();
    const guessInput = document.getElementById("numero");
    const guess = parseInt(guessInput.value);

    if (isNaN(guess) || guess < 1 || guess > 20) {
      resultMessageElement.textContent =
        "Ingresa un número válido entre 1 y 20.";
    } else {
      const difference = guess - targetNumber;

      if (difference === 0) {
        resultMessageElement.textContent = `¡Adivinaste el número ${targetNumber}!`;
        score += 10;
        targetNumber = Math.floor(Math.random() * 20) + 1;
      } else if (difference > 0) {
        resultMessageElement.textContent = "Muy alto!";
        score -= 5;
      } else {
        resultMessageElement.textContent = "Muy bajo!";
        score -= 5;
      }
      highScore += score;

      scoreElement.textContent = score;
      guessInput.value = "";

      if (score <= 0) {
        resultMessageElement.textContent = "¡Perdiste! Tu puntaje llegó a 0.";
        score = 0;
      }
      highScoreElement.textContent = highScore;
    }
  });

  resetButton.addEventListener("click", function () {
    score = 0;
    highScore = 0;
    scoreElement.textContent = score;
    highScoreElement.textContent = highScore;
    resultMessageElement.textContent = "";
    targetNumber = Math.floor(Math.random() * 20) + 1;
  });

  hintButton.addEventListener("click", function () {
    const guessInput = document.getElementById("numero");
    const guess = parseInt(guessInput.value);
    const difference = guess - targetNumber;

    if (isNaN(guess) || guess < 1 || guess > 20) {
      resultMessageElement.textContent =
        "Ingresa un número válido entre 1 y 20.";
    } else {
      if (difference > 0) {
        resultMessageElement.textContent = `Tienes ${difference} números de diferencia.`;
      } else if (difference < 0) {
        resultMessageElement.textContent = `Tienes ${-difference} números de diferencia.`;
      } else {
        resultMessageElement.textContent = `¡Adivinaste el número ${targetNumber}!`;
      }
    }
  });
});
