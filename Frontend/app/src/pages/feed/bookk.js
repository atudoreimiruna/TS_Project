import "./feed.css";

export default function Book(props) {
    const {publishDate, imagePath, userName, description, userId} = props
    const options = { year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric' };
    const readablePublishDate = new Date(publishDate).toLocaleString('en-us', options);

    return (
        <div
            key={readablePublishDate}
            className={"product"}
        >
            { imagePath ? <img
                src={imagePath}
                alt={`Image of ${userId}`}
                className={"image-product"}
            /> : null}
            <h3>{userName} said on {readablePublishDate}:</h3>
            <p>{description}</p>
        </div>
    );
}