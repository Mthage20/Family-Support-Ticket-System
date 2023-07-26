# Family-Support-Ticket-System (ALL sections will be updated as the project moves on)

This project is an support ticket system designed to help me organize issues reported by users, which would be my family. The system allows users to submit tickets describing their issues, and support admins (me) can then view and respond to these tickets. The target users are not necessarily tech-savvy, so the interface should be straightforward and user-friendly.


## Tech Stack

The project uses the following technologies:

- Frontend: React.js for the web interface, React Native for the mobile application.
- Backend: Node.js with Express.js for the server.
- Database: MySQL.


## Key Features

### For Users:

- Ticket Management: Users can submit, edit, and delete their own tickets.
- Ticket Status: Users can view the status of their tickets (not in progress, in progress, done).
- Ticket History: Users can view (and optionally hide/show) a history of their past tickets.
- Issue Category: Users can choose a category for their issue when submitting a ticket.
- Issue Severity: Users can indicate the severity or urgency of their issue when submitting a ticket.
- Notifications: Users can receive notifications when the status of their ticket changes.
- Help Section: Users can access a Help or FAQ section.
- Attachments: Users can attach files or screenshots to their tickets.

### For Admins:

- Ticket Overview: Admins can view all submitted tickets, who submitted them, and when they were submitted.
- Ticket Status Update: Admins can update the ticket status.
- Notifications: Admins can send notifications to users when the status has been updated.
- User Profiles: Admins can view user profiles, including their contact information and a history of their tickets.
- User Account Management: Admins can add, remove, or modify user accounts.
- Admin Notes: Admins can add notes to tickets (visible only to admins).
- Ticket Filtering and Sorting: Admins can filter and sort tickets based on various criteria.
- User Ticket History: Admins can view a user's past tickets when addressing a new ticket.
- Ticket Modification: Admins can modify/delete/add tickets as the user account.
- Dashboard: Admins can access a dashboard that provides a quick overview of the current state of tickets.

## Architectural Design

### Server

I am using Node.js and Express.js for the server. Here's a high-level plan:

1. Install Node.js and npm.
2. Initialize the project with npm, creating a `package.json` file.
3. Install Express.js as a dependency.
4. Create the server in a JavaScript file (e.g., `server.js`), defining a port and setting up a basic route for testing.
5. Run the server and verify it's working correctly.
6. Set up middleware for tasks like parsing JSON request bodies and handling errors.
7. Define API endpoints for handling different types of requests at different URLs.
8. Implement a system for authenticating users and controlling access to API endpoints.
9. Set up a connection to the MySQL database and write queries to fetch, insert, update, and delete data.
10. Handle and report errors, possibly with a global error handler.

### Database Schema

The MySQL database consists of five tables:

- **Users**: Stores information about users.
  - `id`: Unique identifier for each user (Primary Key).
  - `username`: User's username (Unique).
  - `password`: User's hashed password.
  - `role`: User's role (user or admin).
  - `email`: User's email address (Unique).
- **Tickets**: Stores information about tickets.
  - `id`: Unique identifier for each ticket (Primary Key).
  - `user_id`: ID of the user who submitted the ticket (Foreign Key referencing Users.id).
  - `category_id`: ID of the ticket's category (Foreign Key referencing Categories.id).
  - `description`: Description of the issue.
  - `status`: Status of the ticket (not in progress, in progress, done).
  - `priority`: Priority of the ticket.
  - `created_at`: Date and time when the ticket was created.
  - `updated_at`: Date and time when the ticket was last updated.
- **Categories**: Stores different categories that a ticket can belong to.
  - `id`: Unique identifier for each category (Primary Key).
  - `name`: Name of the category.
- **AdminNotes**: Stores notes that admins add to tickets.
  - `id`: Unique identifier for each note (Primary Key).
  - `ticket_id`: ID of the ticket that the note is associated with (Foreign Key referencing Tickets.id).
  - `user_id`: ID of the admin who wrote the note (Foreign Key referencing Users.id).
  - `note`: Text of the note.
  - `created_at`: Date and time when the note was created.
- **Attachments**: Stores information about files that users attach to their tickets.
  - `id`: Unique identifier for each attachment (Primary Key).
  - `ticket_id`: ID of the ticket that the attachment is associated with (Foreign Key referencing Tickets.id).
  - `file_path`: Path where the attachment file is stored.
  - `file_type`: Type of the file (e.g., image, document).
  - `uploaded_at`: Date and time when the attachment was uploaded.

### API Endpoints

Here are the API endpoints:

- **User Authentication**:
  - `POST /auth/register`: Register a new user.
  - `POST /auth/login`: Authenticate a user and return a token.
- **User Management** (mostly for admin use):
  - `GET /users`: Get a list of all users.
  - `GET /users/:id`: Get a specific user's details.
  - `PUT /users/:id`: Update a specific user's details.
  - `DELETE /users/:id`: Delete a specific user.
- **Ticket Management**:
  - `POST /tickets`: Create a new ticket.
  - `GET /tickets`: Get a list of all tickets (for admins) or tickets for a specific user (for users).
  - `GET /tickets/:id`: Get a specific ticket's details.
  - `PUT /tickets/:id`: Update a specific ticket's details.
  - `DELETE /tickets/:id`: Delete a specific ticket.
- **Category Management**:
  - `GET /categories`: Get a list of all categories.
  - `POST /categories`: Create a new category (admin only).
  - `PUT /categories/:id`: Update a specific category (admin only).
  - `DELETE /categories/:id`: Delete a specific category (admin only).
- **Admin Notes Management**:
  - `POST /tickets/:id/adminNotes`: Add a new admin note to a specific ticket.
  - `GET /tickets/:id/adminNotes`: Get a list of all admin notes for a specific ticket.
  - `GET /adminNotes/:id`: Get a specific admin note's details.
  - `PUT /adminNotes/:id`: Update a specific admin note.
  - `DELETE /adminNotes/:id`: Delete a specific admin note.
- **Attachment Management**:
  - `POST /tickets/:id/attachments`: Add a new attachment to a specific ticket.
  - `GET /tickets/:id/attachments`: Get a list of all attachments for a specific ticket.
  - `GET /attachments/:id`: Get a specific attachment's details.
  - `DELETE /attachments/:id`: Delete a specific attachment

### Middleware *(Update this as the project moves on)

Based on the features, database schema, and API endpoints these are the middleware functions i will likely need: 

- Body Parser: This middleware is used to parse incoming request bodies. I will need this to handle JSON payloads in the POST and PUT requests. I could use the `express.json()` middleware for this.
- CORS Middleware: If my frontend and backend are hosted on different domains, I will need to handle Cross-Origin Resource Sharing (CORS). I could use the `cors` package for this.
- Authentication Middleware: This middleware will verify the token in the Authorization header of incoming requests and attach the user's information to the request object. This is necessary for protecting routes that require authentication.
- Error Handling Middleware: This middleware will catch any errors (at least i will try to) that occur during the execution of the route handlers and send an appropriate response to the client. This will be probably be placed at the end of my middleware stack.
- Data Validation Middleware: This middleware will validate the data in incoming requests (e.g., checking that required fields are present in a POST request). I could use packages like `joi` or `express-validator` for this.
- File Upload Middleware: Since users can attach files to their tickets, I will need middleware to handle file uploads. I could use packages like `multer` for this.

## Authentication and Authorization

### Authentication

I will be using JSON Web Tokens (JWT) for authentication. Here's how it applies to the application:

- When a user registers or logs in (via the `POST /auth/register` and `POST /auth/login` endpoints), I will need to verify their credentials. If the credentials are valid, generate a JWT that includes the user's ID and role, and send this token back to the client.
- The client will then include this token in the Authorization header of future requests. I will need to set up middleware (using a package like `express-jwt`) to validate this token for protected routes.
- Passwords should be hashed before being stored in the database. I could use a package like `bcrypt` for this.

### Authorization

I will be using role-based authorization. Here's how it applies to the application:

- The user's role (user or admin) is included in their JWT. When the server receives a request, it should check the role in the JWT to determine if the user is allowed to perform the requested action.

Admins should be able to:

- View all users: `GET /users`
- View a specific user's details: `GET /users/:id`
- Update a specific user's details: `PUT /users/:id`
- Delete a specific user: `DELETE /users/:id`
- Create a new ticket: `POST /tickets`
- View all tickets: `GET /tickets`
- View a specific ticket's details: `GET /tickets/:id`
- Update a specific ticket's details: `PUT /tickets/:id`
- Delete a specific ticket: `DELETE /tickets/:id`
- Create a new category: `POST /categories`
- View all categories: `GET /categories`
- Update a specific category: `PUT /categories/:id`
- Delete a specific category: `DELETE /categories/:id`
- Add a new admin note to a specific ticket: `POST /tickets/:id/adminNotes`
- View all admin notes for a specific ticket: `GET /tickets/:id/adminNotes`
- View a specific admin note's details: `GET /adminNotes/:id`
- Update a specific admin note: `PUT /adminNotes/:id`
- Delete a specific admin note: `DELETE /adminNotes/:id`
- Add a new attachment to a specific ticket: `POST /tickets/:id/attachments`
- View all attachments for a specific ticket: `GET /tickets/:id/attachments`
- View a specific attachment's details: `GET /attachments/:id`
- Delete a specific attachment: `DELETE /attachments/:id`

Users should be able to:

- View their own details: `GET /users/:id` (where `:id` is their own user ID)
- Update their own details: `PUT /users/:id` (where `:id` is their own user ID)
- Create a new ticket: `POST /tickets`
- View their own tickets: `GET /tickets` (the server should filter the tickets based on the user's ID)
- View a specific ticket's details: `GET /tickets/:id` (only if they are the one who submitted the ticket)
- Update a specific ticket's details: `PUT /tickets/:id` (only if they are the one who submitted the ticket)
- Delete a specific ticket: `DELETE /tickets/:id` (only if they are the one who submitted the ticket)
- View all categories: `GET /categories`
- Add a new attachment to a specific ticket: `POST /tickets/:id/attachments` (only if they are the one who submitted the ticket)
- View all attachments for a specific ticket: `GET /tickets/:id/attachments` (only if they are the one who submitted the ticket)
- View a specific attachment's details: `GET /attachments/:id` (only if they are the one who submitted the ticket associated with the attachment)
- Delete a specific attachment: `DELETE /attachments/:id` (only if they are the one who submitted the ticket associated with the attachment)

## Error Handling

The application is designed to handle various types of errors:

- Validation Errors: These occur when the data provided by the user does not meet certain criteria. For example, if a user tries to create a new ticket but doesn't provide a description, the server responds with a validation error.
- Authentication Errors: These occur when a user tries to access a protected resource without providing a valid token or with an expired token. The server responds with an authentication error in these cases.
- Authorization Errors: These occur when a user tries to perform an action that they don't have permission to perform. For example, if a user tries to delete a ticket that they didn't submit, the server responds with an authorization error.
- Database Errors: These occur when there's an issue with a database operation. For example, if a user tries to update a ticket that doesn't exist, the server responds with a database error.
- Server Errors: These are unexpected errors that occur in the server code. The server catches these errors and responds with a generic server error message.

For each of these errors, the server sends an appropriate HTTP status code and error message. For example, validation errors typically result in a 400 Bad Request response, and server errors typically result in a 500 Internal Server Error response. All errors are logged for debugging purposes.
