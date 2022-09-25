# 驾校信息管理系统

目录

[**一、 数据库设计 1**]
[1、需求分析 1]

[2、概念结构设计 2](#_Toc6427)

[3、逻辑结构设计 4](#_Toc6427)

[4、物理结构设计 4](#_Toc6427)

[5、数据库实施 8](#_Toc6427)

[**二、软件设计与实现 12**](#_Toc1271)

[1、软件总体概述 13](#_Toc6427)

[2、各模块的代码实现 15](#_Toc7993)

[3、软件测试 63](#_Toc8562)




## 一.  **数据库设计**

### 1、需求分析

（1）数据查询

1.管理员查询学员或教练的基本信息（以下以学员为例）

输入：学员用户名

输出：学员姓名，性别，年龄，联系电话，身份证，报考类型，报名时间，到期时间，学车时长，已考科目，未考科目，所属教练，可用车辆，可用场地

2.教练查询自己所带学员的基本信息

输入：学员用户名

输出：学员姓名，性别，年龄，联系电话，身份证，报考类型，报名时间，到期时间，学车时长，已考科目，未考科目

3.管理员查询自己的基本信息

输入：管理员用户名

输出：姓名，性别，年龄，身份证，密码

4.教练查询自己的基本信息

输出：教练用户名，姓名，性别，年龄，联系电话，身份证，教龄，所拥有的车辆车牌，所拥有的场地

5.学员查询自己的基本信息

输出：学员用户名，学员姓名，性别，年龄，联系电话，身份证，报考类型，报名时间，到期时间，学车时长，已考科目，未考科目，所属教练，可用车辆，可用场地

6.管理员查询请假信息

输出：用户名，请假原因，请假日期

7.管理员查询自己收到的信息（来自教练/用户）

输入：学员/教练用户名，回复内容

8.教练/学员查询管理员发送的公告或给自己发送的信息

（2）数据插入

1.增加教练/学员，管理员将其基本信息（姓名，性别，年龄，身份证，报考类型等）录入系统，登陆密码自己输入设置，并设置相应权限。

2.管理员给教练分配可用车辆，可用场地等

（3）数据修改

1.管理员修改教练/学员基本信息（姓名，性别，年龄，身份证等）。

2.管理员/教练修改学员已考科目信息。

3.学员学车打卡（记录时间）。

（4）数据删除

1.管理员删除所有科目已考完学员的所有信息，回收登陆账号（删除）。

2.管理员删除已离职教练的所有信息，回收登陆账号（删除）。

### 2、概念结构设计

E-R模型：

![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/37.png)

图 2-1 **学员实体**

![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/38.png)

图 2-2 **教练实体**

![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/39.png)

图 2-3 **管理员实体**

![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/40.png)

图 2-4 **全局E-R**

### 3、逻辑结构设计

关系模式：

学员（学员用户名，学员姓名，性别，年龄，联系电话，身份证，报考类型，报名时间，到期时间，学车时长，已考科目，未考科目，教练用户名，管理员用户名）

教练（教用户名，教练姓名，性别，年龄，联系电话，身份证，教龄，可用车辆，可用场地，管理员用户名）

管理员（管理员用户名，管理员姓名，性别，年龄，身份证，联系电话）

管理员消息表（用户名，消息，回复，日期）

教练消息表（data）学员消息表（data）

教练请假表（用户名，姓名，日期）

签到表（用户名，签到日期）

成绩表结构（用户名，科目1，科目2，科目3，科目4）

### 4、物理结构设计

数据表结构：

表 4-1 学员表结构

| 字段         | 类型      | 特殊属性     |
|--------------|-----------|--------------|
| 学员用户名   | CHAR(10)  | PRIMARY KEY  |
| 学员姓名     | CHAR(20)  | NOT NULL     |
| 性别         | CHAR(2)   | NOT NULL     |
| 年龄         | SMALLINT  | \>=18        |
| 身份证       | CHAR(20)  | UNIQUE       |
| 报考类型     | CHAR(5)   | NOT NULL     |
| 报名时间     | DATE      | NOT NULL     |
| 到期时间     | DATE      | NOT NULL     |
| 学车时长     | SMALLINT  | NOT NULL     |
| 已考科目     | CHAR(10)  |              |
| 未考科目     | CHAR(10)  |              |
| 教练用户名   | CHAR(10)  | FOREIGN KEY  |
| 管理员用户名 | CHAR(10)  | FOREIGN KEY  |
| 联系电话     | NCHAR(20) |              |

表 4- 2 教练表结构

| 字段         | 类型     | 特殊属性     |
|--------------|----------|--------------|
| 教练用户名   | CHAR(10) | PRIMARY KEY  |
| 教练姓名     | CHAR(20) | NOT NULL     |
| 性别         | CHAR(2)  | NOT NULL     |
| 年龄         | SMALLINT |              |
| 身份证       | CHAR(20) | UNIQUE       |
| 教龄         | SMALLINT |              |
| 可用车辆     | CHAR(50) |              |
| 可用场地     | CHAR(20) |              |
| 管理员用户名 | CHAR(10) | FOREIGN KEY  |

表 4- 3 管理员表结构

| 字段         | 类型      | 特殊属性    |
|--------------|-----------|-------------|
| 管理员用户名 | CHAR(10)  | PRIMARY KEY |
| 管理员姓名   | CHAR(20)  | NOT NULL    |
| 性别         | CHAR(2)   | NOT NULL    |
| 年龄         | SMALLINT  |             |
| 身份证       | CHAR(20)  | UNIQUE      |
| 联系电话     | nchar(20) | NOT NULL    |

表 4- 4 签到表结构

| 字段     | 类型        | 特殊类型    |
|----------|-------------|-------------|
| 用户名   | varchar(50) | PRIMARY KEY |
| 签到日期 | nchar(20)   | PRIMARY KEY |

表 4- 5 成绩表结构

| 字段   | 类型        | 特殊类型    |
|--------|-------------|-------------|
| 用户名 | varchar(50) | PRIMARY KEY |
| 科目一 | nchar(20)   | NOT NULL    |
| 科目二 | nchar(20)   | NOT NULL    |
| 科目三 | nchar(20)   | NOT NULL    |
| 科目四 | nchar(20)   | NOT NULL    |

表 4- 6 预约表结构

| 字段       | 类型        | 特殊类型    |
|------------|-------------|-------------|
| 用户名     | varchar(50) | PRIMARY KEY |
| 预约日期   | nchar(20)   | PRIMARY KEY |
| 预约时间段 | nchar(20)   | PRIMARY KEY |

表 4- 7 管理员消息表结构

| 字段   | 类型          | 特殊类型    |
|--------|---------------|-------------|
| 用户名 | varchar(50)   | PRIMARY KEY |
| 姓名   | varchar(50)   |             |
| 消息   | varchar(2000) | NOT NULL    |
| 回复   | varchar(2000) | NOT NULL    |
| 日期   | varchar(5)    | NOT NULL    |

表 4- 8 教练_学员消息表结构

| 字段   | 类型          | 特殊类型    |
|--------|---------------|-------------|
| 用户名 | varchar(50)   | PRIMARY KEY |
| 姓名   | varchar(50)   |             |
| 消息   | varchar(2000) | NOT NULL    |
| 回复   | varchar(2000) | NOT NULL    |
| 日期   | varchar(5)    | NOT NULL    |

表 4- 9 教练请假表结构

| 字段       | 类型        | 特殊类型    |
|------------|-------------|-------------|
| 教练用户名 | varchar(50) | PRIMARY KEY |
| 教练姓名   | nchar(20)   | PRIMARY KEY |
| 请假日期   | nchar(20)   | PRIMARY KEY |

表 4- 10 教练消息表结构

| 字段 | 类型          | 特殊类型    |
|------|---------------|-------------|
| date | varchar(2000) | PRIMARY KEY |

表 4- 11 学员消息表结构

| 字段 | 类型          | 特殊类型    |
|------|---------------|-------------|
| date | varchar(2000) | PRIMARY KEY |

### 5、数据库实施

1.  数据库建立

![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/1.png)

图 5-1-1 建数据库

1.  数据表建立

![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/2.png)

图 5- 2 - 1 管理员表

![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/3.png)

图 5- 2 - 2 教练表

![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/4.png)

图 5- 2 - 3 学员表

![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/5.png)

图 5- 2 - 4 学员表![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/6.png)

图 5- 2 - 5 学员表

## **二、软件设计与实现**

### 1、软件总体概述

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/7.png)**

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/8.png)**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/9.png)

### 2、各模块的代码实现


### 3、软件测试

登录页面通过输入用户名和密码进行登录，可以选择管理员、教练、学员进行登录，密码输入时会由\*代替，保护隐私，如果没有账号则可以点击注册

![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/10.png)

注册页面，通过输入用户名，两次相同的密码，邮箱以及验证码，选择教练或者学员来进行注册，如果两次密码不相同，则会提示密码不一致。

![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/11.png)

学员页面：

![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/12.png)

登录后的学员界面，monthcalender控件运行后会隐藏，查看信息按钮能够接收教练与驾校发送的消息，并且发送消息给教练或驾校。个人信息页面能够查看并修改个人信息。预约练车页面可以预约练车时间，如果当天该时段人数已满四人则会提示重新选择预约时间。驾考成绩页面可以查询自己的驾考通过情况。题库阅览页面可以跳转到题库网页进行预习复习驾考知识点。签到按钮提供当日签到打卡功能。

![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/13.png)

**查看消息页面**

![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/14.png)

**个人信息页面**

![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/15.png)

**预约练车页面**

![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/16.png)

**驾考成绩页面**

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/17.png)**

**题库网页**

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/18.png)**

**签到功能**

**教练页面：**

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/19.png)**

登录后的教练界面，monthcalender控件运行后会隐藏。签到功能可以每日签到，可以阻止一天重复签到。个人信息页面能够查看并修改个人信息。学员信息可以查看该教练教导的学员信息。消息通知可以接收公告信息，对驾校（管理员）发消息，以及对具体学员发送消息，以及接收对方的消息。请假申报可以通过点击具体日期向管理员进行请假，所有请假信息都会被保存下来。

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/20.png)**

**签到功能**

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/21.png)**

**教练个人信息页面**

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/22.png)**

**教练查询学员信息页面**

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/23.png)**

**消息通知页面**

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/24.png)**

**请假申报页面**

**管理员页面：**

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/25.png)**

管理页面主要采用子窗口的模式；管理员可以对自己的个人信息进行查询修改更新操作；在我的消息中可以接收学员、教练的信息。可以添加教练，学员，更改信息，而管理员不能通过注册添加，只能管理员添加。添加学员里有年龄要满18，身份证不能相同，能够查看科目考试情况，报考日期、截至日期等等...管理员还可以查询管理员、学员、教练信息。公告有分学员公告和教练公告，通

过管理员进行编辑。帮助里有查看帮助、发送反馈、检查更新功能。

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/26.png)**

**账户信息页面**

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/27.png)**

**消息页面**

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/28.png)**

**添加/更新管理员页面**

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/29.png)**

**添加/更新教练页面**

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/30.png)**

**添加/更新学员页面**

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/31.png)**

**查询管理员信息页面**

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/32.png)**

**查询教练信息页面**

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/33.png)**

**查询学员信息页面**

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/34.png)**

**查询请假信息页面**

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/35.png)**

**公告页面**

**![](https://github.com/kybky/Driving-school-information-management-system/blob/main/image/36.png)**

**小功能页面**
