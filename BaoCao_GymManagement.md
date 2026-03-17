# BÁO CÁO BÀI TẬP LỚN

## Xây dựng Hệ thống Quản lý Phòng tập Gym

**Trường Đại học Đại Nam**
**Tên học phần:** Thiết Kế Lập Trình BackEnd
**Giáo viên hướng dẫn:** ThS. Tạ Chí Hiếu

| STT | Mã SV | Họ và tên | Lớp |
|---|---|---|---|
| 1 | 1871020550 | Mai Trọng Thế | CNTT 18-09 |
| 2 | 1871020368 | Nguyễn Hải Long | CNTT 18-09 |

**Hà Nội, năm 2025**

---

## BẢNG CÁC TỪ VIẾT TẮT

| STT | Từ viết tắt | Viết đầy đủ |
|---|---|---|
| 1 | MVC | Model - View - Controller |
| 2 | ASP.NET | Active Server Pages .NET |
| 3 | EF | Entity Framework |
| 4 | CRUD | Create, Read, Update, Delete |
| 5 | PT | Personal Trainer - Huấn luyện viên cá nhân |
| 6 | SQL | Structured Query Language |
| 7 | UI | User Interface - Giao diện người dùng |

---

## PHẦN I: MỞ ĐẦU

### 1. Tên đề tài
**"Xây dựng Hệ thống Quản lý Phòng tập Gym (Gym & Fitness Center)"**

### 2. Tính cấp thiết của đề tài

Trong bối cảnh xã hội ngày càng chú trọng đến sức khỏe và thể chất, các phòng tập gym đang phát triển mạnh mẽ trên khắp cả nước. Tuy nhiên, hầu hết các phòng tập gym, đặc biệt là các cơ sở vừa và nhỏ, vẫn đang quản lý thủ công hoặc sử dụng các phần mềm đơn giản, không đáp ứng được nhu cầu quản lý toàn diện:

- **Quản lý hội viên thủ công**: Danh sách thành viên, thẻ tập, ngày hết hạn được ghi chép trên sổ sách dễ gây nhầm lẫn và thất thoát thông tin.
- **Khó kiểm soát check-in**: Không có hệ thống theo dõi ai đang có mặt tại phòng tập, dẫn đến tình trạng sử dụng thẻ trái phép.
- **Quản lý PT rời rạc**: Lịch hẹn với huấn luyện viên cá nhân được quản lý phân tán, dễ xảy ra xung đột lịch.
- **Thiếu dashboard tổng quan**: Quản lý không có cái nhìn toàn diện về tình trạng hoạt động của phòng tập theo thời gian thực.

**Giải pháp**: Xây dựng hệ thống web tập trung trên ASP.NET Core MVC để tự động hóa quy trình, đảm bảo chính xác, minh bạch và cung cấp công cụ quản lý hiệu quả.

### 3. Mục tiêu đề tài

1. **Xây dựng hệ thống quản lý hội viên** đầy đủ: thêm, sửa, xóa, tìm kiếm thông tin hội viên và gói tập.
2. **Phát triển module quản lý PT** và lịch tập.
3. **Triển khai hệ thống check-in/check-out** theo thời gian thực.
4. **Xây dựng Dashboard thống kê** tổng quan cho quản lý.
5. **Tích hợp phân quyền người dùng** (Admin/Staff) đảm bảo bảo mật.

### 4. Phạm vi công việc

- **Phạm vi dữ liệu**: Hệ thống quản lý hội viên, gói tập, PT, lịch tập, check-in
- **Phạm vi người dùng**: Nhân viên lễ tân (Staff) và quản lý phòng tập (Admin)
- **Phạm vi công nghệ**: ASP.NET Core 8.0 MVC, Entity Framework Core, SQL Server
- **Phạm vi thời gian**: 1 kỳ học

---

## PHẦN II: CƠ SỞ LÝ THUYẾT

### 1. Công nghệ sử dụng

#### 2.1.1. ASP.NET Core MVC

ASP.NET Core MVC là một framework phát triển web mạnh mẽ của Microsoft, được xây dựng trên nền tảng .NET Core. Framework này tuân theo mô hình kiến trúc Model-View-Controller (MVC), giúp tách biệt rõ ràng giữa logic nghiệp vụ, giao diện người dùng và xử lý điều hướng. Trong đề tài này, ASP.NET Core 8.0 được sử dụng làm nền tảng chính để xây dựng toàn bộ hệ thống backend và frontend.

#### 2.1.2. Entity Framework Core

Entity Framework Core (EF Core) là một ORM (Object-Relational Mapping) hiện đại của Microsoft. EF Core cho phép lập trình viên làm việc với cơ sở dữ liệu thông qua các đối tượng C# thay vì viết câu lệnh SQL trực tiếp. Trong dự án, EF Core được sử dụng để quản lý các migrations, tạo schema cơ sở dữ liệu và thực hiện các thao tác CRUD.

#### 2.1.3. ASP.NET Core Identity

ASP.NET Core Identity là hệ thống quản lý người dùng tích hợp sẵn trong ASP.NET Core, cung cấp các tính năng xác thực (Authentication) và phân quyền (Authorization). Hệ thống hỗ trợ quản lý người dùng, mật khẩu, vai trò (Roles) và claims. Trong dự án, Identity được cấu hình với hai vai trò chính: Admin và Staff.

#### 2.1.4. SQL Server

Microsoft SQL Server là hệ quản trị cơ sở dữ liệu quan hệ (RDBMS) được sử dụng để lưu trữ toàn bộ dữ liệu của hệ thống. SQL Server tích hợp tốt với ASP.NET Core và Entity Framework Core, hỗ trợ đầy đủ các tính năng như transaction, stored procedure, view và index.

### 2. Kiến trúc hệ thống

Hệ thống được xây dựng theo mô hình MVC ba tầng:

- **Model**: Bao gồm các lớp thực thể (Entity) tương ứng với các bảng trong cơ sở dữ liệu như Member, MembershipType, PersonalTrainer, PTSchedules, CheckInLog, EmailLog. Các model được định nghĩa với Data Annotations để validation.
- **View**: Giao diện người dùng được xây dựng bằng Razor Views (.cshtml), sử dụng Bootstrap 5 để tạo giao diện responsive và thân thiện.
- **Controller**: Xử lý các yêu cầu HTTP, tương tác với cơ sở dữ liệu thông qua ApplicationDbContext và trả về các view tương ứng.

### 3. Mô hình dữ liệu

Hệ thống sử dụng 6 bảng dữ liệu chính với các quan hệ như sau:

- **MembershipTypes – Members** (1-N): Một gói tập có thể được đăng ký bởi nhiều hội viên. Khóa ngoại MembershipTypeID trong bảng Members, với hành vi OnDelete.SetNull.
- **Members – PTSchedules** (1-N): Một hội viên có thể có nhiều lịch tập PT. Khóa ngoại MemberID với OnDelete.Restrict.
- **PersonalTrainers – PTSchedules** (1-N): Một PT có thể có nhiều lịch tập. Khóa ngoại PTID với OnDelete.Restrict.
- **Members – CheckInLogs** (1-N): Một hội viên có nhiều lần check-in. Khóa ngoại MemberID với OnDelete.Cascade.
- **Members – EmailLogs** (1-N): Lưu lịch sử gửi email thông báo cho hội viên.

---

## PHẦN III: PHÂN TÍCH VÀ THIẾT KẾ HỆ THỐNG

### 1. Phân tích yêu cầu

#### 3.1.1. Yêu cầu chức năng

- **Quản lý gói tập (MembershipTypes)**: Cho phép tạo, chỉnh sửa, xóa các gói tập với thông tin tên gói, thời hạn (ngày), giá tiền và mô tả.
- **Quản lý hội viên (Members)**: Quản lý đầy đủ thông tin hội viên bao gồm họ tên, email, số điện thoại, ngày sinh, địa chỉ, số thẻ, gói tập đăng ký, ngày bắt đầu, ngày hết hạn và trạng thái.
- **Quản lý PT (PersonalTrainers)**: Quản lý thông tin huấn luyện viên cá nhân gồm họ tên, email, số điện thoại, chuyên môn, giá theo giờ và trạng thái sẵn sàng.
- **Quản lý lịch PT (PTSchedules)**: Đặt lịch tập giữa PT và hội viên với thông tin ngày, giờ bắt đầu, giờ kết thúc, loại buổi tập và ghi chú.
- **Quản lý check-in (CheckInLogs)**: Ghi nhận thời gian vào/ra của hội viên kèm số thẻ.
- **Dashboard thống kê**: Hiển thị tổng số hội viên, hội viên đang hoạt động, số PT, số PT sẵn sàng, lịch hẹn hôm nay, lượt check-in hôm nay, số người đang trong phòng tập, hội viên sắp hết hạn.

#### 3.1.2. Yêu cầu phi chức năng

- **Bảo mật**: Hệ thống yêu cầu đăng nhập trước khi truy cập. Phân quyền rõ ràng giữa Admin và Staff. Sử dụng Anti-Forgery Token để chống CSRF.
- **Hiệu năng**: Sử dụng async/await cho toàn bộ các thao tác I/O với database. Eager Loading (Include) để tối ưu số lượng truy vấn.
- **Tính khả dụng**: Giao diện responsive, tương thích với các thiết bị khác nhau. Thông báo lỗi rõ ràng khi người dùng nhập sai dữ liệu.

### 2. Thiết kế cơ sở dữ liệu

#### 3.2.1. Bảng MembershipTypes (Gói tập)

| Thuộc tính | Kiểu dữ liệu | Mô tả |
|---|---|---|
| MembershipTypeID | int (PK) | Mã gói tập (khóa chính) |
| TypeName | nvarchar(100) | Tên gói tập |
| DurationDays | int | Thời hạn gói tập (ngày) |
| Price | decimal(18,2) | Giá gói tập (VNĐ) |
| Description | nvarchar(500) | Mô tả gói tập |
| CreatedAt | datetime | Thời gian tạo bản ghi |

#### 3.2.2. Bảng Members (Hội viên)

| Thuộc tính | Kiểu dữ liệu | Mô tả |
|---|---|---|
| MemberID | int (PK) | Mã hội viên (khóa chính) |
| FullName | nvarchar(100) | Họ và tên hội viên |
| Email | nvarchar(100) | Email liên lạc |
| Phone | nvarchar(20) | Số điện thoại |
| MembershipTypeID | int (FK) | Mã gói tập (khóa ngoại) |
| StartDate | datetime | Ngày bắt đầu gói tập |
| EndDate | datetime? | Ngày hết hạn gói tập |
| Status | nvarchar(20) | Trạng thái (Active/Inactive) |
| MembershipCardNo | nvarchar(50) | Số thẻ thành viên |

#### 3.2.3. Bảng PersonalTrainers (Huấn luyện viên)

| Thuộc tính | Kiểu dữ liệu | Mô tả |
|---|---|---|
| PTID | int (PK) | Mã PT (khóa chính) |
| FullName | nvarchar(100) | Họ và tên PT |
| Specialization | nvarchar(200) | Chuyên môn |
| HourlyRate | decimal(18,2)? | Giá theo giờ (VNĐ) |
| IsAvailable | bit | Trạng thái sẵn sàng nhận lịch |

#### 3.2.4. Bảng PTSchedules (Lịch tập PT)

| Thuộc tính | Kiểu dữ liệu | Mô tả |
|---|---|---|
| ScheduleID | int (PK) | Mã lịch tập (khóa chính) |
| PTID | int (FK) | Mã huấn luyện viên (khóa ngoại) |
| MemberID | int (FK) | Mã hội viên (khóa ngoại) |
| ScheduleDate | datetime | Ngày tập |
| StartTime | time | Giờ bắt đầu buổi tập |
| EndTime | time | Giờ kết thúc buổi tập |
| SessionType | nvarchar(50)? | Loại buổi tập |
| Notes | nvarchar(500)? | Ghi chú thêm |
| Status | nvarchar(20) | Trạng thái (Scheduled/Completed/Cancelled) |
| CreatedAt | datetime | Thời gian tạo bản ghi |

#### 3.2.5. Bảng CheckInLogs (Lịch sử check-in)

| Thuộc tính | Kiểu dữ liệu | Mô tả |
|---|---|---|
| LogID | int (PK) | Mã log check-in (khóa chính) |
| MemberID | int (FK) | Mã hội viên (khóa ngoại) |
| CheckInTime | datetime | Thời gian hội viên vào phòng tập |
| CheckOutTime | datetime? | Thời gian hội viên ra (null = đang trong phòng) |
| CardNo | nvarchar(50)? | Số thẻ sử dụng khi check-in |
| CreatedAt | datetime | Thời gian tạo bản ghi |

#### 3.2.6. Bảng EmailLogs (Lịch sử gửi email)

| Thuộc tính | Kiểu dữ liệu | Mô tả |
|---|---|---|
| EmailLogID | int (PK) | Mã log email (khóa chính) |
| MemberID | int (FK) | Mã hội viên nhận email (khóa ngoại) |
| EmailType | nvarchar(50)? | Loại email (nhắc gia hạn, xác nhận,...) |
| SentAt | datetime | Thời gian gửi email |
| Status | nvarchar(20)? | Trạng thái gửi (Success/Failed) |
| ErrorMessage | nvarchar(500)? | Thông báo lỗi nếu gửi thất bại |

### 3. Thiết kế kiến trúc ứng dụng

Hệ thống được tổ chức theo cấu trúc thư mục chuẩn của ASP.NET Core MVC:

- **Controllers/**: Chứa 7 controller xử lý logic nghiệp vụ: HomeController, DashboardController, MembersController, MembershipTypesController, PersonalTrainersController, PTSchedulesController, CheckInLogsController.
- **Models/**: Chứa 7 model thực thể: Member, MembershipType, PersonalTrainer, PTSchedules, CheckInLog, EmailLog, ErrorViewModel. Ngoài ra có DashboardViewModel được định nghĩa inline trong DashboardController.
- **Data/**: Chứa ApplicationDbContext kế thừa từ IdentityDbContext, cấu hình tất cả các quan hệ giữa các bảng.
- **Services/**: Chứa RoleInitializer để khởi tạo các vai trò và tài khoản mẫu khi ứng dụng khởi động.
- **Views/**: Chứa các Razor views (.cshtml) tương ứng với từng controller, được tổ chức thành các thư mục con.
- **Migrations/**: Chứa các file migration EF Core để quản lý schema database.

### 4. Sơ đồ logic ER (Entity - Relationship)

Sơ đồ ER của hệ thống GymManagement gồm 6 thực thể chính với các quan hệ như sau:

- **MembershipTypes – Members** (1-N): Một gói tập có thể được đăng ký bởi nhiều hội viên. Khóa ngoại MembershipTypeID trong bảng Members với hành vi ON DELETE SET NULL, đảm bảo dữ liệu hội viên không bị mất khi xóa gói tập.
- **Members – PTSchedules** (1-N): Một hội viên có thể có nhiều lịch tập PT. Khóa ngoại MemberID trong bảng PTSchedules với hành vi ON DELETE RESTRICT, ngăn xóa hội viên khi còn lịch tập liên kết.
- **PersonalTrainers – PTSchedules** (1-N): Một huấn luyện viên có thể phụ trách nhiều lịch tập. Khóa ngoại PTID với hành vi ON DELETE RESTRICT.
- **Members – CheckInLogs** (1-N): Một hội viên có thể có nhiều bản ghi check-in. Khóa ngoại MemberID với hành vi ON DELETE CASCADE.
- **Members – EmailLogs** (1-N): Một hội viên có thể nhận nhiều email thông báo. Khóa ngoại MemberID với hành vi ON DELETE CASCADE.

### 5. Chi tiết các bảng dữ liệu (SQL)

```sql
-- HỆ THỐNG QUẢN LÝ PHÒNG TẬP GYM - GymManagement Database Schema
-- Phiên bản: 1.0 | Ngày tạo: 2026-03-17

CREATE DATABASE GymManagementDB
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_unicode_ci;
USE GymManagementDB;

-- BẢNG 1: MembershipTypes (Gói tập)
-- Lưu trữ các gói tập mà phòng gym cung cấp.
-- Một gói tập có thể được đăng ký bởi nhiều hội viên (1-N).
CREATE TABLE MembershipTypes (
    MembershipTypeID    INT             PRIMARY KEY AUTO_INCREMENT   COMMENT 'Mã gói tập, khóa chính tự tăng',
    TypeName            VARCHAR(100)    NOT NULL                     COMMENT 'Tên gói tập (VD: Gói 1 tháng, Gói 3 tháng...)',
    DurationDays        INT             NOT NULL                     COMMENT 'Thời hạn của gói tập tính theo ngày',
    Price               DECIMAL(18,2)   NOT NULL                     COMMENT 'Giá gói tập tính theo VNĐ',
    Description         VARCHAR(500)                                 COMMENT 'Mô tả chi tiết về quyền lợi của gói tập',
    CreatedAt           DATETIME        DEFAULT CURRENT_TIMESTAMP    COMMENT 'Thời điểm tạo bản ghi',
    INDEX idx_typename (TypeName)
) COMMENT = 'Bảng lưu trữ các loại gói tập của phòng gym';

-- BẢNG 2: Members (Hội viên)
-- Liên kết với MembershipTypes (N-1), PTSchedules (1-N), CheckInLogs (1-N), EmailLogs (1-N).
CREATE TABLE Members (
    MemberID            INT             PRIMARY KEY AUTO_INCREMENT   COMMENT 'Mã hội viên, khóa chính tự tăng',
    FullName            VARCHAR(100)    NOT NULL                     COMMENT 'Họ và tên đầy đủ của hội viên',
    Email               VARCHAR(100)    NOT NULL                     COMMENT 'Địa chỉ email liên lạc',
    Phone               VARCHAR(20)                                  COMMENT 'Số điện thoại liên lạc',
    DateOfBirth         DATE                                         COMMENT 'Ngày sinh của hội viên',
    Address             VARCHAR(200)                                 COMMENT 'Địa chỉ nhà của hội viên',
    MembershipCardNo    VARCHAR(50)     UNIQUE                       COMMENT 'Số thẻ thành viên, duy nhất trong hệ thống',
    MembershipTypeID    INT                                          COMMENT 'Mã gói tập đang đăng ký, khóa ngoại tới MembershipTypes',
    StartDate           DATETIME        DEFAULT CURRENT_TIMESTAMP    COMMENT 'Ngày bắt đầu hiệu lực của gói tập',
    EndDate             DATETIME                                     COMMENT 'Ngày hết hạn gói tập',
    Status              VARCHAR(20)     DEFAULT 'Active'             COMMENT 'Trạng thái hội viên: Active / Inactive / Suspended',
    CreatedAt           DATETIME        DEFAULT CURRENT_TIMESTAMP    COMMENT 'Thời điểm tạo bản ghi',
    UpdatedAt           DATETIME        ON UPDATE CURRENT_TIMESTAMP  COMMENT 'Thời điểm cập nhật bản ghi gần nhất',
    FOREIGN KEY (MembershipTypeID) REFERENCES MembershipTypes(MembershipTypeID)
        ON DELETE SET NULL,
    INDEX idx_email      (Email),
    INDEX idx_status     (Status),
    INDEX idx_enddate    (EndDate),
    INDEX idx_membertype (MembershipTypeID)
) COMMENT = 'Bảng lưu trữ thông tin hội viên đăng ký tập tại phòng gym';

-- BẢNG 3: PersonalTrainers (Huấn luyện viên cá nhân)
CREATE TABLE PersonalTrainers (
    PTID                INT             PRIMARY KEY AUTO_INCREMENT   COMMENT 'Mã huấn luyện viên, khóa chính tự tăng',
    FullName            VARCHAR(100)    NOT NULL                     COMMENT 'Họ và tên đầy đủ của huấn luyện viên',
    Email               VARCHAR(100)                                 COMMENT 'Địa chỉ email liên lạc của PT',
    Phone               VARCHAR(20)                                  COMMENT 'Số điện thoại liên lạc của PT',
    Specialization      VARCHAR(200)                                 COMMENT 'Chuyên môn của PT',
    HourlyRate          DECIMAL(18,2)                                COMMENT 'Mức phí theo giờ tính theo VNĐ',
    IsAvailable         TINYINT(1)      DEFAULT 1                    COMMENT 'Trạng thái sẵn sàng nhận lịch: 1 = Có, 0 = Không',
    CreatedAt           DATETIME        DEFAULT CURRENT_TIMESTAMP    COMMENT 'Thời điểm tạo bản ghi',
    INDEX idx_pt_available (IsAvailable)
) COMMENT = 'Bảng lưu trữ thông tin huấn luyện viên cá nhân của phòng gym';

-- BẢNG 4: PTSchedules (Lịch tập PT)
CREATE TABLE PTSchedules (
    ScheduleID          INT             PRIMARY KEY AUTO_INCREMENT   COMMENT 'Mã lịch tập, khóa chính tự tăng',
    PTID                INT             NOT NULL                     COMMENT 'Mã PT phụ trách buổi tập, khóa ngoại tới PersonalTrainers',
    MemberID            INT             NOT NULL                     COMMENT 'Mã hội viên tham gia buổi tập, khóa ngoại tới Members',
    ScheduleDate        DATE            NOT NULL                     COMMENT 'Ngày diễn ra buổi tập',
    StartTime           TIME            NOT NULL                     COMMENT 'Giờ bắt đầu buổi tập',
    EndTime             TIME            NOT NULL                     COMMENT 'Giờ kết thúc buổi tập',
    SessionType         VARCHAR(50)                                  COMMENT 'Loại buổi tập',
    Notes               VARCHAR(500)                                 COMMENT 'Ghi chú thêm',
    Status              VARCHAR(20)     DEFAULT 'Scheduled'          COMMENT 'Trạng thái: Scheduled / Completed / Cancelled',
    CreatedAt           DATETIME        DEFAULT CURRENT_TIMESTAMP    COMMENT 'Thời điểm tạo bản ghi',
    FOREIGN KEY (PTID)     REFERENCES PersonalTrainers(PTID) ON DELETE RESTRICT,
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID)     ON DELETE RESTRICT,
    INDEX idx_schedule_date   (ScheduleDate),
    INDEX idx_schedule_ptid   (PTID),
    INDEX idx_schedule_member (MemberID),
    INDEX idx_schedule_status (Status)
) COMMENT = 'Bảng lưu trữ lịch tập giữa hội viên và huấn luyện viên cá nhân';

-- BẢNG 5: CheckInLogs (Lịch sử check-in)
-- CheckOutTime = NULL nghĩa là hội viên đang ở trong phòng tập.
CREATE TABLE CheckInLogs (
    LogID               INT             PRIMARY KEY AUTO_INCREMENT   COMMENT 'Mã log check-in, khóa chính tự tăng',
    MemberID            INT             NOT NULL                     COMMENT 'Mã hội viên thực hiện check-in, khóa ngoại tới Members',
    CheckInTime         DATETIME        DEFAULT CURRENT_TIMESTAMP    COMMENT 'Thời điểm hội viên vào phòng tập',
    CheckOutTime        DATETIME                                     COMMENT 'Thời điểm hội viên ra khỏi phòng tập, NULL = đang trong phòng',
    CardNo              VARCHAR(50)                                  COMMENT 'Số thẻ sử dụng khi check-in',
    CreatedAt           DATETIME        DEFAULT CURRENT_TIMESTAMP    COMMENT 'Thời điểm tạo bản ghi',
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID) ON DELETE CASCADE,
    INDEX idx_checkin_member (MemberID),
    INDEX idx_checkin_time   (CheckInTime),
    INDEX idx_checkout_time  (CheckOutTime)
) COMMENT = 'Bảng ghi lịch sử ra vào phòng tập của hội viên';

-- BẢNG 6: EmailLogs (Lịch sử gửi email)
CREATE TABLE EmailLogs (
    EmailLogID          INT             PRIMARY KEY AUTO_INCREMENT   COMMENT 'Mã log email, khóa chính tự tăng',
    MemberID            INT             NOT NULL                     COMMENT 'Mã hội viên nhận email, khóa ngoại tới Members',
    EmailType           VARCHAR(50)                                  COMMENT 'Loại email: RenewalReminder / WelcomeEmail / Promotion...',
    SentAt              DATETIME        DEFAULT CURRENT_TIMESTAMP    COMMENT 'Thời điểm gửi email',
    Status              VARCHAR(20)                                  COMMENT 'Trạng thái gửi: Success / Failed / Pending',
    ErrorMessage        VARCHAR(500)                                 COMMENT 'Thông báo lỗi chi tiết nếu gửi thất bại',
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID) ON DELETE CASCADE,
    INDEX idx_email_member (MemberID),
    INDEX idx_email_type   (EmailType),
    INDEX idx_email_status (Status)
) COMMENT = 'Bảng lưu lịch sử gửi email thông báo cho hội viên';
```

---

## PHẦN IV: THIẾT KẾ API BACKEND

### 1. Kiến trúc BackEnd

Hệ thống được tổ chức theo mô hình MVC Monolithic đơn giản, phù hợp cho đồ án sinh viên:

```
Client (Browser / Mobile)
         ↓
Authentication Layer (ASP.NET Core Identity · Phân quyền Admin/Staff)
         ↓
Controllers Layer (API Routes / Endpoints)
  ├── HomeController          [Public]
  ├── DashboardController     [Authorize]
  ├── MembersController       [Admin, Staff]
  ├── MembershipTypesController
  ├── PersonalTrainersController
  ├── PTSchedulesController   [Admin, Staff]
  └── CheckInLogsController
         ↓
Models Layer (Business Logic)
  Member · MembershipType · PersonalTrainer
  PTSchedules · CheckInLog · EmailLog · DashboardViewModel
         ↓
Data Access Layer (ApplicationDbContext · Entity Framework Core · Migrations)
         ↓
Database (SQL Server · GymManagementDB)
```

### 2. Danh sách API Endpoint

#### 4.2.1. DashboardController [Authorize]

| Method | Route | Action | Mô tả |
|---|---|---|---|
| GET | /Dashboard | Index | Tổng quan: tổng hội viên, PT, check-in hôm nay, sắp hết hạn |

#### 4.2.2. MembersController [Authorize(Roles = Admin, Staff)]

| Method | Route | Action | Mô tả |
|---|---|---|---|
| GET | /Members | Index | Danh sách hội viên kèm gói tập |
| GET | /Members/Details/{id} | Details | Chi tiết một hội viên |
| GET | /Members/Create | Create | Form tạo hội viên mới |
| POST | /Members/Create | Create | Lưu hội viên mới vào database |
| GET | /Members/Edit/{id} | Edit | Form chỉnh sửa hội viên |
| POST | /Members/Edit/{id} | Edit | Cập nhật thông tin hội viên |
| GET | /Members/Delete/{id} | Delete | Xác nhận xóa hội viên |
| POST | /Members/Delete/{id} | DeleteConfirmed | Xóa hội viên khỏi database |

#### 4.2.3. MembershipTypesController

| Method | Route | Action | Mô tả |
|---|---|---|---|
| GET | /MembershipTypes | Index | Danh sách gói tập |
| GET | /MembershipTypes/Details/{id} | Details | Chi tiết gói tập |
| GET | /MembershipTypes/Create | Create | Form tạo gói tập mới |
| POST | /MembershipTypes/Create | Create | Lưu gói tập mới vào database |
| GET | /MembershipTypes/Edit/{id} | Edit | Form chỉnh sửa gói tập |
| POST | /MembershipTypes/Edit/{id} | Edit | Cập nhật gói tập |
| GET | /MembershipTypes/Delete/{id} | Delete | Xác nhận xóa gói tập |
| POST | /MembershipTypes/Delete/{id} | DeleteConfirmed | Xóa gói tập khỏi database |

#### 4.2.4. PersonalTrainersController

| Method | Route | Action | Mô tả |
|---|---|---|---|
| GET | /PersonalTrainers | Index | Danh sách huấn luyện viên |
| GET | /PersonalTrainers/Details/{id} | Details | Chi tiết huấn luyện viên |
| GET | /PersonalTrainers/Create | Create | Form thêm huấn luyện viên mới |
| POST | /PersonalTrainers/Create | Create | Lưu huấn luyện viên mới vào database |
| GET | /PersonalTrainers/Edit/{id} | Edit | Form chỉnh sửa huấn luyện viên |
| POST | /PersonalTrainers/Edit/{id} | Edit | Cập nhật thông tin huấn luyện viên |
| GET | /PersonalTrainers/Delete/{id} | Delete | Xác nhận xóa huấn luyện viên |
| POST | /PersonalTrainers/Delete/{id} | DeleteConfirmed | Xóa huấn luyện viên khỏi database |

#### 4.2.5. PTSchedulesController [Authorize(Roles = Admin, Staff)]

| Method | Route | Action | Mô tả |
|---|---|---|---|
| GET | /PTSchedules | Index | Danh sách lịch tập kèm thông tin PT và hội viên |
| GET | /PTSchedules/Details/{id} | Details | Chi tiết buổi tập PT |
| GET | /PTSchedules/Create | Create | Form đặt lịch tập mới |
| POST | /PTSchedules/Create | Create | Lưu lịch tập mới vào database |
| GET | /PTSchedules/Edit/{id} | Edit | Form chỉnh sửa lịch tập |
| POST | /PTSchedules/Edit/{id} | Edit | Cập nhật lịch tập |
| GET | /PTSchedules/Delete/{id} | Delete | Xác nhận xóa lịch tập |
| POST | /PTSchedules/Delete/{id} | DeleteConfirmed | Xóa lịch tập khỏi database |

#### 4.2.6. CheckInLogsController

| Method | Route | Action | Mô tả |
|---|---|---|---|
| GET | /CheckInLogs | Index | Lịch sử check-in của toàn bộ hội viên |
| GET | /CheckInLogs/Details/{id} | Details | Chi tiết một lần check-in |
| GET | /CheckInLogs/Create | Create | Form ghi nhận check-in thủ công |
| POST | /CheckInLogs/Create | Create | Lưu bản ghi check-in mới |
| GET | /CheckInLogs/Edit/{id} | Edit | Form cập nhật giờ vào/ra |
| POST | /CheckInLogs/Edit/{id} | Edit | Cập nhật bản ghi check-in (bổ sung CheckOutTime) |
| GET | /CheckInLogs/Delete/{id} | Delete | Xác nhận xóa bản ghi check-in |
| POST | /CheckInLogs/Delete/{id} | DeleteConfirmed | Xóa bản ghi check-in khỏi database |

#### 4.2.7. HomeController [Public]

| Method | Route | Action | Mô tả |
|---|---|---|---|
| GET | / | Index | Trang chủ công khai |
| GET | /Home/Privacy | Privacy | Trang chính sách bảo mật |
| GET | /Home/Error | Error | Trang thông báo lỗi hệ thống |

---

## PHẦN V: CHẠY CODE VÀ CHƯƠNG TRÌNH

### 5.1. Giao diện đăng nhập

Hệ thống yêu cầu người dùng đăng nhập trước khi truy cập các chức năng quản lý. Trang đăng nhập được cung cấp bởi ASP.NET Core Identity với form nhập email và mật khẩu.

*[Hình 5.1. Giao diện trang đăng nhập]*

### 5.2. Giao diện Dashboard tổng quan

Sau khi đăng nhập thành công, người dùng được chuyển đến trang Dashboard hiển thị các thống kê tổng quan theo thời gian thực bao gồm tổng số hội viên, số PT, lượt check-in hôm nay và số hội viên sắp hết hạn.

*[Hình 5.2. Giao diện Dashboard tổng quan hệ thống]*

### 5.3. Quản lý hội viên

#### 5.3.1. Danh sách hội viên

Trang danh sách hội viên hiển thị toàn bộ thông tin hội viên kèm gói tập đang đăng ký, trạng thái và ngày hết hạn.

*[Hình 5.3. Trang danh sách hội viên]*

#### 5.3.2. Thêm hội viên mới

Form thêm hội viên mới cho phép nhập đầy đủ thông tin cá nhân, chọn gói tập và thiết lập ngày bắt đầu.

*[Hình 5.4. Form thêm hội viên mới]*

#### 5.3.3. Chỉnh sửa thông tin hội viên

Form chỉnh sửa cho phép cập nhật toàn bộ thông tin hội viên. Hệ thống xử lý xung đột đồng thời (DbUpdateConcurrencyException) để đảm bảo tính toàn vẹn dữ liệu.

*[Hình 5.5. Form chỉnh sửa thông tin hội viên]*

### 5.4. Quản lý gói tập

#### 5.4.1. Danh sách gói tập

*[Hình 5.6. Trang danh sách gói tập]*

#### 5.4.2. Thêm / Chỉnh sửa gói tập

*[Hình 5.7. Form thêm/chỉnh sửa gói tập]*

### 5.5. Quản lý huấn luyện viên cá nhân (PT)

#### 5.5.1. Danh sách huấn luyện viên

*[Hình 5.8. Trang danh sách huấn luyện viên cá nhân]*

#### 5.5.2. Thêm huấn luyện viên mới

*[Hình 5.9. Form thêm huấn luyện viên mới]*

### 5.6. Quản lý lịch tập PT

#### 5.6.1. Danh sách lịch tập

*[Hình 5.10. Trang danh sách lịch tập PT]*

#### 5.6.2. Đặt lịch tập mới

*[Hình 5.11. Form đặt lịch tập PT mới]*

### 5.7. Quản lý check-in/check-out

#### 5.7.1. Danh sách lịch sử check-in

*[Hình 5.12. Trang danh sách lịch sử check-in]*

#### 5.7.2. Ghi nhận check-in

*[Hình 5.13. Form ghi nhận check-in hội viên]*

---

## KẾT LUẬN

### Kết quả đạt được

Sau quá trình nghiên cứu, phân tích và triển khai, nhóm đã hoàn thành việc xây dựng hệ thống quản lý phòng tập Gym trên nền tảng ASP.NET Core MVC 8.0. Các kết quả cụ thể đạt được bao gồm:

- Thiết kế và triển khai cơ sở dữ liệu gồm 6 bảng chính với đầy đủ quan hệ khóa ngoại, ràng buộc toàn vẹn và index tối ưu truy vấn trên SQL Server.
- Xây dựng 7 Controller với tổng cộng 41 endpoint, đầy đủ chức năng CRUD, áp dụng lập trình bất đồng bộ (async/await) để tối ưu hiệu năng.
- Tích hợp ASP.NET Core Identity với hệ thống phân quyền hai cấp (Admin/Staff), bảo vệ các route nhạy cảm bằng attribute Authorize và chống tấn công CSRF bằng Anti-Forgery Token.
- Xây dựng Dashboard thống kê thời gian thực với 8 chỉ số quan trọng giúp quản lý nắm bắt tình trạng hoạt động của phòng tập.
- Triển khai hệ thống check-in/check-out cho phép theo dõi hội viên ra vào phòng tập theo thời gian thực.
- Xây dựng giao diện người dùng responsive sử dụng Bootstrap 5 và Razor Views, thân thiện trên cả thiết bị desktop và mobile.

### Ưu điểm

- Kiến trúc MVC rõ ràng, tách biệt giữa logic nghiệp vụ, giao diện và điều hướng, giúp hệ thống dễ bảo trì và mở rộng.
- Toàn bộ thao tác với database sử dụng async/await, giúp tối ưu hiệu năng server khi xử lý nhiều yêu cầu đồng thời.
- Hệ thống bảo mật chặt chẽ với phân quyền theo vai trò, mã hóa mật khẩu và kiểm soát truy cập theo từng chức năng.

### Nhược điểm và hướng cải thiện

- Chưa triển khai tính năng gửi email tự động nhắc hội viên gia hạn gói tập mặc dù schema bảng EmailLog đã được chuẩn bị sẵn.
- Dashboard chưa có biểu đồ thống kê trực quan theo thời gian.
- Chưa có tính năng xuất báo cáo ra file PDF hoặc Excel.

### Hướng phát triển

- Phát triển module gửi email tự động sử dụng Background Service để nhắc hội viên gia hạn khi còn 7 ngày hết hạn.
- Bổ sung biểu đồ thống kê trực quan trên Dashboard sử dụng thư viện Chart.js.
- Xây dựng RESTful API để hỗ trợ ứng dụng mobile quản lý phòng tập.
- Thêm tính năng xuất báo cáo PDF/Excel cho danh sách hội viên và lịch sử check-in.

---

## PHÂN CÔNG NHIỆM VỤ

| STT | MSV | Họ và tên | Nhiệm vụ |
|---|---|---|---|
| 1 | 1871020550 | Mai Trọng Thế | Xây dựng Models (PersonalTrainer, PTSchedules, CheckInLog, EmailLog); MembersController, PersonalTrainersController, PTSchedulesController, CheckInLogsController, DashboardController + Views; Identity, phân quyền, RoleInitializer, Program.cs; Báo cáo: Chương 2, 3, 4, Kết luận, Phân công (70%) |
| 2 | 1871020368 | Nguyễn Hải Long | Xây dựng Models (Member, MembershipType), ApplicationDbContext, Migration; MembershipTypesController + Views; HomeController + Layout; Báo cáo: Chương 1, Bảng từ viết tắt, Tài liệu tham khảo (30%) |

---

## DANH MỤC TÀI LIỆU THAM KHẢO

1. Microsoft Corporation (2024), *ASP.NET Core documentation*, Microsoft Docs, https://docs.microsoft.com/aspnet/core.
2. Microsoft Corporation (2024), *Entity Framework Core documentation*, Microsoft Docs, https://docs.microsoft.com/ef/core.
3. Microsoft Corporation (2024), *ASP.NET Core Identity documentation*, Microsoft Docs, https://docs.microsoft.com/aspnet/core/security/authentication/identity.
4. Microsoft Corporation (2024), *ASP.NET Core MVC documentation*, Microsoft Docs, https://docs.microsoft.com/aspnet/core/mvc.
5. Microsoft Corporation (2024), *SQL Server documentation*, Microsoft Docs, https://docs.microsoft.com/sql/sql-server.
6. Andrew Lock (2023), *ASP.NET Core in Action*, Third Edition, Manning Publications, New York.
7. Jon P Smith (2021), *Entity Framework Core in Action*, Second Edition, Manning Publications, New York.
8. Adam Freeman (2022), *Pro ASP.NET Core 6: Develop Cloud-Ready Web Applications Using MVC, Blazor, and Razor Pages*, Apress, New York.
9. Bootstrap Team (2024), *Bootstrap 5 documentation*, https://getbootstrap.com/docs/5.0.
10. Troelsen Andrew, Japikse Philip (2021), *Pro C# 9 with .NET 5: Foundational Principles and Practices in Programming*, Apress, New York.
11. Esposito Dino (2020), *Modern Web Development with ASP.NET Core 3*, Microsoft Press, Washington.
12. Martin Robert C. (2008), *Clean Code: A Handbook of Agile Software Craftsmanship*, Prentice Hall, New Jersey.

---

*Báo cáo được soạn thảo phục vụ môn học **Thiết Kế Lập Trình BackEnd** - Năm học 2025-2026*
