function handleLoginClick() {
    window.location.href = "http://localhost:29496/dang-nhap";
}

function toggleDropdown() {
    const dropdown = document.getElementById('dropdownMenu');
    // Ẩn/hiện menu khi nhấp vào hình ảnh
    if (dropdown.style.display === 'none' || dropdown.style.display === '') {
        dropdown.style.display = 'block';
    } else {
        dropdown.style.display = 'none';
    }
}

function logout() {
    // Khi đăng xuất, quay trở lại form đăng nhập
    document.getElementById('loginForm').style.display = 'block';
    document.getElementById('profile').style.display = 'none';
    document.getElementById('username').value = '';
    document.getElementById('password').value = '';

    // Đảm bảo ẩn menu thông tin
    document.getElementById('dropdownMenu').style.display = 'none';
}
//Search bar
// Lấy các phần tử cần thiết
const searchContainer = document.getElementById("searchContainer");
const searchBox = document.getElementById("searchBox");
const searchInput = document.getElementById("searchInput");
const searchIcon = document.getElementById("searchIcon");

// Khi click vào search box, mở rộng và hiện input
searchBox.addEventListener("click", function (event) {
    searchBox.classList.add("active");
    searchInput.focus();
    event.stopPropagation(); // Ngăn sự kiện click truyền ra ngoài
});

// Khi click vào biểu tượng search-icon, gọi sự kiện tìm kiếm
searchIcon.addEventListener("click", function (event) {
    event.stopPropagation(); // Ngăn sự kiện click truyền ra ngoài

    const searchText = searchInput.value;
    console.log("Search event triggered with text:", searchText);

    // Reset search box
    resetSearchBox();
});

// Khi click ra ngoài searchContainer, trở lại trạng thái ban đầu
document.addEventListener("click", function (event) {
    if (!searchContainer.contains(event.target)) {
        resetSearchBox();
    }
});

// Hàm reset search box về trạng thái ban đầu
function resetSearchBox() {
    searchBox.classList.remove("active");
    searchInput.value = ""; // Xóa văn bản trong input nếu muốn
}

//Ẩn hiện pass
function togglePassword() {
    const passwordInput = document.getElementById("password");
    const toggleIcon = document.querySelector(".toggle-password");

    // Kiểm tra loại input hiện tại
    if (passwordInput.type === "password") {
        passwordInput.type = "text";
        toggleIcon.textContent = "🙈"; // Đổi icon để thể hiện đang hiện mật khẩu
    } else {
        passwordInput.type = "password";
        toggleIcon.textContent = "👁️"; // Đổi lại icon để thể hiện đang ẩn mật khẩu
    }
}
