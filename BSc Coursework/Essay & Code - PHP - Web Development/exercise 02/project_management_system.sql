-- phpMyAdmin SQL Dump
-- version 2.9.0.3
-- http://www.phpmyadmin.net
-- 
-- Host: localhost
-- Generation Time: Dec 19, 2006 at 03:01 AM
-- Server version: 5.0.27
-- PHP Version: 5.2.0
-- 
-- Database: `project_management_system`
-- 

-- --------------------------------------------------------

-- 
-- Table structure for table `manager`
-- 

CREATE TABLE `manager` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `name` varchar(25) NOT NULL,
  `surname` varchar(25) NOT NULL,
  `e_mail_address` varchar(30) NOT NULL,
  `telephone` char(13) NOT NULL,
  `username` char(10) NOT NULL,
  `md5_password` char(32) NOT NULL,
  PRIMARY KEY  (`id`),
  KEY `Index_on_username` USING BTREE (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- 
-- Dumping data for table `manager`
-- 


-- --------------------------------------------------------

-- 
-- Table structure for table `managers_messages`
-- 

CREATE TABLE `managers_messages` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `prog_id` int(10) unsigned NOT NULL,
  `man_id` int(10) unsigned NOT NULL,
  `subject` varchar(45) NOT NULL,
  `message` text NOT NULL,
  `send_time` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  `read` tinyint(1) NOT NULL default '0',
  PRIMARY KEY  (`id`),
  KEY `FK_managers_messages_prog_id` (`prog_id`),
  KEY `FK_managers_messages_man_id` (`man_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- 
-- Dumping data for table `managers_messages`
-- 


-- --------------------------------------------------------

-- 
-- Table structure for table `programmer`
-- 

CREATE TABLE `programmer` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `name` varchar(25) NOT NULL,
  `surname` varchar(25) NOT NULL,
  `e_mail_address` varchar(30) NOT NULL,
  `telephone` char(13) NOT NULL,
  `username` char(10) NOT NULL,
  `md5_password` char(32) NOT NULL,
  PRIMARY KEY  (`id`),
  KEY `Index_on_username` USING BTREE (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- 
-- Dumping data for table `programmer`
-- 


-- --------------------------------------------------------

-- 
-- Table structure for table `programmers_messages`
-- 

CREATE TABLE `programmers_messages` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `man_id` int(10) unsigned NOT NULL,
  `prog_id` int(10) unsigned NOT NULL,
  `subject` varchar(45) NOT NULL,
  `message` text NOT NULL,
  `send_time` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  `read` tinyint(1) NOT NULL default '0',
  PRIMARY KEY  (`id`),
  KEY `FK_programmers_messages_man_id` (`man_id`),
  KEY `FK_programmers_messages_prog_id` (`prog_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- 
-- Dumping data for table `programmers_messages`
-- 


-- --------------------------------------------------------

-- 
-- Table structure for table `project`
-- 

CREATE TABLE `project` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `name` varchar(45) NOT NULL,
  `start_date` char(10) NOT NULL,
  `end_date` char(10) NOT NULL,
  `description` text NOT NULL,
  `logo_path` varchar(80) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- 
-- Dumping data for table `project`
-- 


-- --------------------------------------------------------

-- 
-- Table structure for table `task_assignment`
-- 

CREATE TABLE `task_assignment` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `proj_id` int(10) unsigned NOT NULL,
  `prog_id` int(10) unsigned NOT NULL,
  `title` varchar(45) NOT NULL,
  `description` text NOT NULL,
  `hours_spent` float unsigned NOT NULL,
  `acomplished` tinyint(1) unsigned NOT NULL default '0',
  PRIMARY KEY  (`id`,`proj_id`,`prog_id`),
  KEY `FK_task_assignment_proj_id` (`proj_id`),
  KEY `FK_task_assignment_prog_id` (`prog_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- 
-- Dumping data for table `task_assignment`
-- 


-- 
-- Constraints for dumped tables
-- 

-- 
-- Constraints for table `managers_messages`
-- 
ALTER TABLE `managers_messages`
  ADD CONSTRAINT `FK_managers_messages_man_id` FOREIGN KEY (`man_id`) REFERENCES `manager` (`id`) ON UPDATE CASCADE,
ALTER TABLE `managers_messages`
  ADD CONSTRAINT `FK_managers_messages_man_id` FOREIGN KEY (`man_id`) REFERENCES `manager` (`id`) ON UPDATE CASCADE,  ADD CONSTRAINT `FK_managers_messages_prog_id` FOREIGN KEY (`prog_id`) REFERENCES `programmer` (`id`) ON UPDATE CASCADE;

-- 
-- Constraints for table `programmers_messages`
-- 
ALTER TABLE `programmers_messages`
  ADD CONSTRAINT `FK_programmers_messages_man_id` FOREIGN KEY (`man_id`) REFERENCES `manager` (`id`) ON UPDATE CASCADE,
ALTER TABLE `programmers_messages`
  ADD CONSTRAINT `FK_programmers_messages_man_id` FOREIGN KEY (`man_id`) REFERENCES `manager` (`id`) ON UPDATE CASCADE,  ADD CONSTRAINT `FK_programmers_messages_prog_id` FOREIGN KEY (`prog_id`) REFERENCES `programmer` (`id`) ON UPDATE CASCADE;

-- 
-- Constraints for table `task_assignment`
-- 
ALTER TABLE `task_assignment`
  ADD CONSTRAINT `FK_task_assignment_prog_id` FOREIGN KEY (`prog_id`) REFERENCES `programmer` (`id`) ON UPDATE CASCADE,
ALTER TABLE `task_assignment`
  ADD CONSTRAINT `FK_task_assignment_prog_id` FOREIGN KEY (`prog_id`) REFERENCES `programmer` (`id`) ON UPDATE CASCADE,  ADD CONSTRAINT `FK_task_assignment_proj_id` FOREIGN KEY (`proj_id`) REFERENCES `project` (`id`) ON UPDATE CASCADE;
