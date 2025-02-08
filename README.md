# TS_Project

## Book Summary API

This project is a Flask-based API that generates summaries for books using the `Summarizer` class from the `booookscore` package. The summarizer leverages the `mixtral-8x7b-32768` model and uses an API key from Groq.

### Installation

1. **Clone the repository**

2. **Create a virtual environment**:
    ```bash
    python -m venv venv
    source venv/bin/activate  # On Windows use `venv\Scripts\activate`
    ```

3. **Install the required packages**:
    ```bash
    pip install -r requirements.txt
    ```

4. **Ensure you have the necessary files**:
    - `all_books_chunked_512.pkl`: This file should contain the chunked book data.
    - `summaries.json`: This file will store the generated summaries.
    - `api_key.txt`: This file should contain your Groq API key.

### Usage

1. **Run the Flask application**:
    ```bash
    python app.py
    ```

2. **Access the API**:
    - The API will be available at `http://localhost:5000`.

### API Endpoints

#### Get Summary API

- **URL**: `/api/summary`
- **Method**: `POST`
- **Request Body**:
    ```json
    {
        "title": "Book Title"
    }
    ```
- **Response**:
    ```json
    {
        "summary": "Generated summary of the book."
    }
    ```
