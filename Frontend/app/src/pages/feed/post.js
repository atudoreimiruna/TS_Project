export default function Post(props) {
    const {publishDate, title, userName, comment} = props
    const options = { year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric' };
    const readablePublishDate = new Date(publishDate).toLocaleString('en-us', options);

    return (
        <div
            key={readablePublishDate}
            className={"product"}
        >
            <h3>{userName} reviewed the book {title} on {readablePublishDate}:</h3>
            <p>{comment}</p>
        </div>
    );
}