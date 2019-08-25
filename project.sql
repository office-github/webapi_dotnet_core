-- create database project

-- use project

drop table if exists user;
drop table if exists attendance;

CREATE TABLE `user` (
  `symbolnumber` bigint NOT NULL,
  `fullname` varchar(250) DEFAULT NULL,
  `email` varchar(250) DEFAULT NULL,
  `phoneno` bigint,
  PRIMARY KEY (`symbolnumber`)
);

CREATE TABLE `attendance` (
  `symbolnumber` bigint NOT NULL,
  `attendancedate` datetime not null,
  `ispresent` bool default false,
  foreign key(`symbolnumber`) references user(symbolnumber)
);

ALTER TABLE user MODIFY symbolnumber BIGINT;
ALTER TABLE user MODIFY phoneno BIGINT;
ALTER TABLE attendance MODIFY symbolnumber BIGINT;

insert into user values(1111, 'Ranjan Mishra', 'rm@gmail.com', 9911882277);
insert into attendance values(1111, now(), true);

select * from user;
select * from attendance;

delete from user where symbolnumber = null;

