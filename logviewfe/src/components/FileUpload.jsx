import React, { useState } from "react";

const FileInput = () => {
  const [file, setFile] = useState();

  function handleChange(event) {
    setFile(event.target.files[0]);
  }

  function handleSubmit(event) {
    event.preventDefault();
    const token = localStorage.getItem('token');
    const formData = new FormData();
    formData.append("file", file);

    fetch("https://localhost:7025/log/upload", {
      method: "POST",
      body: formData,
      headers:{
        'Authorization': `Bearer ${token}`
      }
    })
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
      })
      .catch((error) => {
        console.error(error);
      });
  }

  return (
    <div className="App">
      <form onSubmit={handleSubmit}>
        <h1>React File Upload</h1>
        <input type="file" name="file" onChange={handleChange} />
        <button type="submit">Upload</button>
      </form>
    </div>
  );
};

export default FileInput;
