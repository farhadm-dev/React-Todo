/* eslint-disable react/jsx-key */
import { useEffect, useState } from "react";
import "./App.css";
import axios from "axios";

import { MdDeleteOutline } from "react-icons/md";
import { IoMdAdd } from "react-icons/io";

function App() {
  const [data, setData] = useState([]);

  const getData = () => {
    axios
      .get("api/data/GetData")
      .then((result) => {
        setData(result.data);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  useEffect(() => {
    getData();
  }, []);

  const [inputs, setInputs] = useState({});

  const handleSubmit = (e) => {
    e.preventDefault();
    axios
      .post("api/data/GetData", inputs)
      .then((res) => {
        console.log(res);
      })
      .catch((err) => {
        console.log(err);
      })
      .finally(() => {
        setInputs({});
        window.location.reload();
      });
  };
  const handleDelete = (id) => {
    axios
      .delete(`/api/data/GetData/${id}`)
      .then((res) => {
        console.log(res);
      })
      .catch((err) => {
        console.log(err);
      })

      .finally(() => {
        window.location.reload();
      });
  };
  const handleChange = (e) => {
    const name = e.target.name;
    const value = String(e.target.value);
    setInputs((prevState) => ({ ...prevState, [name]: value }));
  };

  return (
    <>
      <div className="mainDiv">
        <form
          style={{
            display: "flex",
            flexDirection: "row",
            justifyContent: "center",
          }}
          onSubmit={handleSubmit}
        >
          <div className="insertDiv">
            <input
              className="inputDiv"
              placeholder="Insert Task..."
              name="message"
              value={inputs.message || ""}
              onChange={handleChange}
            />
          </div>
          <button className="submitB" type="submit">
            <IoMdAdd size={"20"} />
          </button>
        </form>

        <div>
          <h3 className="yourT">Your Todos</h3>
        </div>

        {data.map((x) => (
          <div className="dataDiv">
            <p>{x.message}</p>

            <div>
              <button
                onClick={() => handleDelete(x.id)}
                style={{ backgroundColor: "transparent", border: "none" }}
              >
                <MdDeleteOutline size={"24"} color="maroon" />
              </button>
            </div>
          </div>
        ))}
      </div>
    </>
  );
}

export default App;
