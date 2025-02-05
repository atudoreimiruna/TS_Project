from flask import Flask, request, jsonify
from booookscore.summ import Summarizer

app = Flask(__name__)

def generate_summary(book_title):
    summarizer = Summarizer(
        model="your_model",
        api="openai",
        api_key="/api_key.txt",
        summ_path="path_to_summary",
        method="inc",
        chunk_size=512,
        max_context_len=2048,
        max_summary_len=512,
        word_ratio=0.65
    )
    summary = summarizer.summarize(book_title)
    return summary

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