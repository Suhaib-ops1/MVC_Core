document.addEventListener("DOMContentLoaded", () => {
  const elements = document.querySelectorAll(".animate"); // اختيار العناصر

  setTimeout(() => {
    elements.forEach((element) => {
      element.classList.add("visible"); // إضافة الـ class لجعل العنصر يظهر
    });
  }, 500); // وقت التأخير (500 مللي ثانية)
});

const sign = document.getElementById("sign");
const ride = document.getElementById("ride");
const profile = document.getElementById("prof");

window.onload = function () {
  var isLogged = sessionStorage.getItem("isLogged");
  console.log(isLogged);
  if (isLogged === "true") {
    sign.hidden = true;
    ride.hidden = false;
    profile.hidden= false;
  }
};