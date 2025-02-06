from flask import Flask, request, jsonify
from booookscore.summ import Summarizer
import os
import json
import pickle

app = Flask(__name__)

def generate_summary(book_title):
    # Define paths
    book_path = f"all_books_chunked_128.pkl"  # Assuming the chunked data is saved as a pickle file
    summ_path = "summaries.json"  # Path for storing summaries

    # Initialize the summarizer
    summarizer = Summarizer(
        model="gpt-4",
        api="openai",
        api_key="./api_key.txt",
        summ_path=summ_path,
        method="inc",
        chunk_size=128,  # Reduced chunk size
        max_context_len=256,  # Reduced context length
        max_summary_len=200,  # Shortened summary length
        word_ratio=0.5  # Reduce compression ratio if needed
    )

    
    # Check if chunked data exists
    if not os.path.exists(book_path):
        return "Book data not found!", 404

    # Run summarization process
    summarizer.get_summaries(book_path)

    # Load the final summary from the generated summaries
    if os.path.exists(summ_path):
        with open(summ_path, 'r') as f:
            summaries = json.load(f)
        final_summary = summaries.get(book_title, {}).get('final_summary', "No summary available")
        return final_summary
    else:
        return "Summaries file not found.", 404

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

