# 🎮 Quiz Game (Unity)

Đây là project Quiz Game mình phát triển bằng Unity nhằm luyện tập kiến thức về C#, quản lý dữ liệu và xây dựng hệ thống game theo level.

---

## 🎯 Giới thiệu

Quiz Game là trò chơi trả lời câu hỏi trắc nghiệm theo từng màn (level). Ở mỗi level, người chơi sẽ trả lời một tập câu hỏi và nhận điểm tương ứng với số câu đúng.

Điểm số cao nhất của mỗi level sẽ được lưu lại để người chơi có thể cải thiện thành tích ở những lần chơi sau.

---

## ✨ Chức năng hiện tại

* Chơi quiz theo từng level
* Mỗi level có bộ câu hỏi riêng (load từ JSON)
* Tính điểm khi trả lời đúng
* Lưu điểm cao nhất của từng level
* Tự động Load dữ liệu khi vào game

---

## 💾 Hệ thống lưu dữ liệu

Game sử dụng file JSON để lưu dữ liệu local:

* Lưu điểm cao nhất theo level
* Dữ liệu được ghi vào persistentDataPath
* Có thể mở rộng thêm unlock level, số sao, thống kê, v.v.

Cách tiếp cận này giúp dễ dàng mở rộng hệ thống save về sau.

---

## 🛠️ Công nghệ sử dụng

* Unity Engine
* Ngôn ngữ C#
* ScriptableObject để quản lý cấu hình
* JSON để lưu và đọc dữ liệu

---

## 🚀 Cách chạy project

1. Clone repository về máy
2. Mở bằng Unity Hub
3. Mở scene chính
4. Nhấn Play để chạy game

---

## 📌 Hướng phát triển thêm

* Thêm nhiều bộ câu hỏi hơn
* Thêm hệ thống unlock level
* Thêm hiệu ứng và polish gameplay
* Bổ sung leaderboard (online)

---

## 👤 Tác giả

Unity Developer (Project cá nhân phục vụ học tập & portfolio)
