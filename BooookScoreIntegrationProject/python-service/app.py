from flask import Flask, request, jsonify
from functions.summ import Summarizer
import os
import json
import pickle

app = Flask(__name__)

def generate_summary(book_title):
    # Define paths
    book_path = f"all_books_chunked_512.pkl"  
    summ_path = "summaries.json" 

    # Initialize the summarizer
    summarizer = Summarizer(
        model="mixtral-8x7b-32768",
        api="groq",
        api_key="./api_key.txt",
        summ_path=summ_path,
        method="inc",
        chunk_size=512,  
        max_context_len=1024, 
        max_summary_len=1024, 
    )

    
    if not os.path.exists(book_path):
        return "Book data not found!", 404


    if os.path.exists(summ_path):
        with open(summ_path, 'r') as f:
            summaries = json.load(f)
        return summaries.get(book_title, {}).get('final_summary', "No summary available")
    else:
        return summarizer.get_summaries(book_path)


@app.route('/')
def home():
    return "Welcome to the Book Summary API!"

@app.route('/api/summary', methods=['POST'])
def get_summary():
    data = request.json
    book_title = data.get('title')
    summary = generate_summary(book_title)
    return jsonify({"summary": summary})

if __name__ == "__main__":
    app.run(debug=True)

