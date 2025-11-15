// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.getElementById("profileForm").addEventListener("submit", (e) => {
    e.preventDefault();
    const skills = document.getElementById("skills").value;
    localStorage.setItem("userSkills", skills);
    alert("Profile saved!");
});
