// JavaScript để thay đổi dữ liệu khi chọn tháng/năm khác
const monthInput = document.getElementById("month");
const displayMonth = document.getElementById("displayMonth");
monthInput.addEventListener("change", () => {
    const selectedDate = new Date(monthInput.value);
    const month = selectedDate.getMonth() + 1; // Lấy tháng (0-11) nên cần +1
    const year = selectedDate.getFullYear();    // Lấy năm
    // Sử dụng fetch API để gửi AJAX yêu cầu
    fetch('/NhanVien/YourAjaxAction', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ selectedMonth: month })
    })
        .then(response => response.json())
        .then(data => {
            console.log(data.message); // Xử lý phản hồi từ server nếu cần
        });
    displayMonth.textContent = `Tháng: ${month}, Năm: ${year}`; // thay đổi hiển thị tháng
    window.location.href = "http://localhost:29496/NhanVien";
});