import { useState } from "react";
import { _post } from "../../utils/api";

export default function Boook(props) {
    const {id, imagePath, title, description, author} = props
    const [summary, setSummary] = useState();

    const fetchSummary = () => {
        _post('https://localhost:44335/api/Books/get-summary', { title: 'reminiscences-of-pioneer-days-in-st-paul'}).then(response => setSummary(response.data.summary));
    }

    return (
        <div
            key={id}
            className={"product"}
        >
            <img
                src={imagePath}
                alt={`Image of ${title}`}
                className={"image-product"}
            />
            <h3>{`${title} by ${author}`}</h3>
            <p>{description}</p>
            <button className={"summary-button"} onClick={fetchSummary}> Summary </button>
            {
                summary && <p> {summary} </p>
            }
        </div>
    );
}