# TS_Project

Book Summary API
This project is a Flask-based API that generates summaries for books using the Summarizer class from the booookscore package. The summarizer leverages the mixtral-8x7b-32768 model and uses an API key from Groq.

**Installation**
Clone the repository
Create a virtual environment:
  python -m venv venv
  source venv/bin/activate  # On Windows use `venv\Scripts\activate`
Install the required packages:
  pip install -r requirements.txt
Ensure you have the necessary files:
  - all_books_chunked_512.pkl: This file should contain the chunked book data.
  - summaries.json: This file will store the generated summaries.
  - api_key.txt: This file should contain your Groq API key.

**Usage**
Run the Flask application:
  python app.py
Access the API:
The API will be available at http://localhost:5000
Get Summary API
URL: /api/summary
Method: POST
Request Body:
{
    "title": "Book Title"
}
Response:
{
    "summary": "Generated summary of the book."
}
