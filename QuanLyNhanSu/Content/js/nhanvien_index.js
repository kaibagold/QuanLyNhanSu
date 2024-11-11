// JavaScript để thay đổi dữ liệu khi chọn tháng/năm khác
const monthInput = document.getElementById("month");
monthInput.addEventListener("change", () => {
    // Giả sử khi thay đổi tháng/năm thì dữ liệu sẽ được cập nhật lại
    const newBasicSalary = "12,000,000";
    const newBHXH = "900,000";
    const newBHYT = "400,000";
    const newPhuCap = "600,000";
    const newTNCN = "600,000";
    const newTienThuong = "1,500,000";
    const newTienPhat = "150,000";

    // Tính tổng tiền mới
    const newTongTien = "13,650,000";

    // Cập nhật dữ liệu trong bảng
    document.getElementById("basicSalary").textContent = newBasicSalary;
    document.getElementById("bhxh").textContent = newBHXH;
    document.getElementById("bhyt").textContent = newBHYT;
    document.getElementById("phuCap").textContent = newPhuCap;
    document.getElementById("ttncn").textContent = newTNCN;
    document.getElementById("tienThuong").textContent = newTienThuong;
    document.getElementById("tienPhat").textContent = newTienPhat;
    document.getElementById("tongTien").textContent = newTongTien;
});