﻿Feature: LogIn_Feature
	In order to access my account
    As a user of the website
    I want to log into the website
 
@mytag
Scenario: Successful Login with Valid Credentials
	Given User is at the Login Page
	When User enter UserName and Password and Click on the LogIn button
	Then User is at Home page

