## Academy Management App++
## The solution should include everything we have learned so far, including MVC
User Roles & Actions
Admin

Login: Admins can log in using unique credentials.
Dashboard: Access a dashboard with various management tools.
User Management:
Add/Remove Users: Can add or remove Trainers and Students.
Manage Admins: Can add other Admins but cannot remove themselves.
Assign Subjects: Can assign subjects to Trainers.
Generate Reports: Can generate reports on students’ performance and subjects.
Exception Handling: Notify if the user already exists, if the username is not found, or if attempting to remove themselves.
Trainer

Login: Trainers can log in using unique credentials.
Dashboard: Access a dashboard with teaching tools.
Student Management:
View Students: See a list of all students and their subjects.
Student Details: View detailed information about each student, including grades.
Subject Management:
View Subjects: See all subjects along with the number of students enrolled.
Assign Grades: Can add or update grades for students in their subjects.
Exception Handling: Notify if attempting to grade students not enrolled in their subject, or if data is incomplete.
Student

Login: Students can log in using unique credentials.
Dashboard: Access a personalized dashboard.
Subject Overview: View the current subject they are enrolled in.
Grades: View a list of their grades for all subjects.
Exception Handling: Notify if there are no subjects assigned or if grades are missing.
Additional Enhancements
Authentication & Authorization

Role-based Access: Ensure actions are restricted based on the user role.
Secure Login: Implement secure password handling (e.g., hashing).
Data Validation

Input Validation: Validate all input data to ensure consistency and integrity.
Data Integrity: Ensure that the removal of users does not orphan related data (e.g., grades without students).
Reporting & Analytics

Generate Reports: Admins can generate performance reports for students and subjects.
Dashboard Analytics: Admin dashboard displays key metrics (e.g., average grades, number of students per subject).
Notifications

Email Alerts: Send notifications to users (e.g., new grades for students, changes in subjects for trainers).
User Experience


User-friendly UI: Design an intuitive interface for all user roles.
MVC Design Implementation
Models
User Model

Attributes: username, password, role, etc.
Methods: authenticate, add_user, remove_user, etc.
Student Model

Attributes: name, subjects, grades, etc.
Methods: get_subjects, get_grades, etc.
Subject Model

Attributes: subject_name, students_enrolled, etc.
Methods: assign_student, get_students, etc.
Grade Model

Attributes: student, subject, grade, etc.
Methods: add_grade, update_grade, etc.
Views
Login View: Form for user login.
Admin Dashboard View: Interface for managing users, subjects, and generating reports.
Trainer Dashboard View: Interface for managing students and subjects.
Student Dashboard View: Interface for viewing subjects and grades.
Controllers
AuthController: Handles login, logout, and session management.
AdminController: Manages admin-specific actions like adding/removing users and assigning subjects.
TrainerController: Manages trainer-specific actions like viewing students and subjects, and assigning grades.
StudentController: Manages student-specific actions like viewing subjects and grades.
Example Exception Handling Scenarios
Admin Attempts to Remove Themselves: Notify that admins cannot remove themselves and suggest to transfer rights first.
Trainer Assigns Grade to Non-Enrolled Student: Notify that the student is not enrolled in the subject.
Student Accesses Grades with No Subjects Assigned: Notify that no subjects are currently assigned and suggest contacting the admin.
This enhanced set of requirements and MVC design will provide a robust foundation for the Academy Management app, ensuring it is scalable, maintainable, and user-friendly.

## Next Steps
Design Database Schema: Outline tables and relationships for storing users, subjects, grades, etc.

Develop Models: Implement data handling and business logic.
Create Views: Design user interfaces for different roles.
Build Controllers: Handle interactions between users, views, and models.
