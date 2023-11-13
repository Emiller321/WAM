# Group 45 Senior Design Team Contract

University of Cincinnati 

College of Education, Criminal Justice and Human Services 

School of Information Technology 

 

Eric Miller, Samuel Ishida, Dylan Leonard, Karthikeya Thota, Zongyu Xu 
## Intent

The following contract was written and agreed upon by Eric Miller, Samuel Ishida, Dylan Leonard, Karthikeya Thota, Zongyu Xu 

 

The contract provides expectations, objectives, and results for developing the Multipoint Bluetooth application. 

 

The contract is effective for all team members participating in the Senior Design Capstone class series in the 2023-2024 academic year.  

## Project Summary

This project is about having an application to be able to connect to multiple devices at the same time. Over time we would like our application to be powerful enough to be able to have multiple Bluetooth connections on devices and being able to control the bass or treble individually on those devices.  

## Problem Statement

The problem we are trying to solve is having the ability to connect to multiple Bluetooth devices at a base source for use as an audio controller.  There are currently ways to connect multiple Bluetooth 4.0 or newer devices using built-in multi-point connectivity, but this is limited to other Bluetooth 4.0 enabled devices and does not allow for individualized control of each audio output device.  The other issue with multiple Bluetooth audio output devices connected to one audio source is that there can be issues with audio output synchronization, as there can be various issues with data rates changing based on distance or the Bluetooth connection type.  Beyond general connectivity and audio controller functionality, there is also the concerns of secure Bluetooth connections at events where bad actors may attempt to attack the network operations. 

Currently the affected users are Apple iPhone owners where multi-point Bluetooth connection is only possible with Apple devices, DJs who are looking to have mobile operations with simple audio controls, and Bluetooth audio listeners who would like to connect to multiple devices for personal use either on the go with earbuds and headphones or within their residence using home theater systems. 

## Solution

The solution to these problems would be the Wireless Audio Manager (WAM) which utilizes a web browser software to connect multiple Bluetooth devices, using Bluetooth Low Energy (BLE), and controls the audio outputs by detecting data rates and latency to synchronize all output devices.  WAM will also show each audio output device as an individual section with specific controls for that one speaker, including audio volume, input separation, and surround sound settings.  The Bluetooth connections will be secured by using NIST framework for BLE connections and implementing private device addressing for those connections. 

## Contact Information

![image](https://github.com/Emiller321/WAM/assets/54557245/6ebeb034-d209-449a-b4e1-94c7191aa427)


## Project Source

This project was originally inspired by our shared passion for music.  To start from the beginning, our team was formed when we all met in the first lecture of our Senior Design class.  After listening to a few other group's pitches, we were all still looking for something different from any of their proposed projects or the sponsored projects, thus we were the final few who remained without a group and decided to get to know each other a bit.  Quickly we found out that there was a shared passion for music, and after throwing around a few ideas we ended up identifying a problem with Bluetooth audio devices.  It can be difficult to successfully connect multiple Bluetooth speakers to play a song simultaneously, and to go beyond that control the audio output on each individual device all from a single phone or computer.  We had thus defined the three main problems we have decided to solve and began discussing the requirements analysis immediately.  

## Project Objectives/Goals

### Main Goals/Objectives: 

Connecting multiple Bluetooth devices through one source 

Being able to individually control the audio inputs and outputs of each Bluetooth device connected 

Syncing Bluetooth audio outputs to minimize latency 

Securing the Bluetooth connections using NIST frameworks and Bluetooth Low Energy security protocols  

### Subgoals/Objectives:

Create individual audio controls for volume and surround sound settings 

Adjust application for different environments(testing)  

Creating plug-ins for music application Spotify 

Measuring latency on each Bluetooth connected device 

Interpret input audio for mixing and separation to different speakers 

## Team Members and Responsibilities

Eric Miller – Development Role - Front End Development - Tester 

Samuel Ishida – Development Role – Back End Development - Tester 

Dylan Leonard – Security Role, Team Manager, Research 

Zongyu Xu – Security Role, Research 

Karthikeya Thota – Security Role, Research 

## Project Scope

We will create the application name WAM that enables users to connect and interact with multiple devices. Our design goals include developing reliable connectivity mechanisms that allow applications to connect to a variety of devices. Facilitates the exchange of data between connected devices, supporting various data types such as text, files, images and multimedia. Design an intuitive and user-friendly interface to simplify device discovery, connection management, and data sharing. Implement robust security measures to protect data transmission, user privacy, and prevent unauthorized access to connected devices. As much as possible, make sure the app is compatible with major operating systems, including Windows, Android, and iOS.  

For our application we will plan to do project Initiation (define project, scope, and team role, Research and Planning (Research device communication protocols and technologies and create detailed project plan), Development (coding, design elements, and focus on security, Testing and Quality Assurance. 

## Technologies Used

The technologies we will use for our application include the following: 1. wireless communication protocol such as Bluetooth or Wi-Fi. 2. Audio streaming protocol is to transmit audio data between devices. 3. Device Discovery is implementing a method for discovering and pairing with available devices. 4. Security ensures secure communication and data privacy, especially if our application deals with personal audio content. 5. User Interface, we will create a user-friendly interface for users to discover, connect, and control multiple speakers. 6. Testing and Quality Assurance, at the last step we will test our application to ensure that it is maintained across various devices and network conditions.  

## Ethical and Legal Considerations 

The development of any technology, including the project outlined in the senior design contract, must take ethical and legal issues into account. Here, we'll identify a few potential moral and legal conundrums and talk about solutions: 

### Ethics-Related Matters: 
Concerns about privacy and data security are raised by the possibility that user data would be collected and stored as part of the project. Users provide us with their personal information when they connect their Bluetooth devices to our app. Their location, the devices they are using, and their audio preferences might all be included in this information. Customer data must be protected and only used for what it was meant for. Put effective data protection and encryption measures in place. 

Security: Because Bluetooth is a wireless technology, it is open to hacking. You must take precautions to secure your app and prevent unwanted access to user data. 

Transparency: Users should be made aware of the purposes for which their data will be used and given the choice to agree or object. To earn users' trust, data collection and use must be transparent. 

Bias and Fairness: It's crucial to make sure that any audio preferences—such as bass and treble—can be adjusted in the application without bias or prejudice. User preferences should be taken into account when making audio modifications rather than any demographic considerations. 

Consider accessibility for all users, including those with disabilities, to promote inclusivity. Make sure the application is created with a varied variety of users in mind and is accessible to them. 

User Consent: Before connecting to users' Bluetooth devices, make sure that they have given their clear, informed consent. Users ought to have control over who has access to their data, what devices are connected, and how it is used. 

Test the application frequently with a variety of users and collect their comments. According to moral principles, you ought to use this criticism to enhance the product and fix any problems that surface. 

### Legal Concerns: 
Data protection regulations Whenever necessary, abide by data protection rules including the California Consumer Privacy Act (CCPA) and the General Data Protection Regulation (GDPR). These regulations control the gathering, storing, and processing of user data. 

Intellectual Property: Honor the rights to intellectual property. Make sure we have the authority to utilize any software or third-party technology incorporated into the application. 

Check the application's compliance with Bluetooth's specs and standards. Legal problems could result from non-compliance. 

Draft clear and thorough terms of service and privacy policies that describe how user data will be used, users' rights and obligations, and the company's liabilities. 

Security Rules: Comply with cybersecurity rules and guidelines to guard user data from hacks and breaches. 

Comply with accessibility laws, such as the Americans with impairments Act (ADA), to make sure that people with impairments can access the application. 


### To address these moral and legal issues: 
Conduct extensive research to stay current on applicable legislation and moral principles. 

Work together with legal professionals to guarantee adherence to all relevant laws. 

Create and put into place effective data security and protection procedures. 

Encourage development of our team to make ethical decisions in all circumstances. 

Keep users informed and involved so they can decide how to use the program and how their data is used. 

## Team Rules

The following are rules that have been set forth by and to be upheld by each member of the project team.  The enforcement of the rules will be done by the team members who will raise these issues with the team and ultimately the instructors if further actions is needed. 

- Plagiarism will not be tolerated. Any team member that plagiarizes will be subject to university policies and a team meeting will be called. 

- Each team member will stay current on their tasks to ensure the project milestones are being met. If an event conflicts that will affect the completion of a deliverable, the team member will notify the other team members at least 24 hours in advance of the scheduled due date. 

- If a group member will be absent on class days or for an extended period of time, they will notify the other team members and the instructors. 

- Team members are expected to respond to group messages that prompt such response within 24 hours of receiving the message unless there is a previously discussed justification. 

- Each team member is expected to independently research issues that they encounter or bring the issues to the group to assign out the research to another group member. 

- For conflict resolution the group members are expected to bring the issue to the rest of the group to deliberate upon the outcome. 

- If any member of the group feels uncomfortable or unsure of anything they should address the issue with the rest of the group, or at least the group manager to resolve this issue, reaching out to instructors if needed. 

- Work done on any project tasks will be reviewed by at least one other group member before finalizing the deliverable. 
