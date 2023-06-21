import React, { useEffect } from "react";
import FileInput from "./FileUpload";
import {Table} from "./Table";

const Dashboard = () => {
  const rows = [
    {
      id: 1,
      name: "Liz Lemon",
      age: 36,
      is_manager: true,
      start_date: "02-28-1999",
    },
    {
      id: 2,
      name: "Jack Donaghy",
      age: 40,
      is_manager: true,
      start_date: "03-05-1997",
    },
    {
      id: 3,
      name: "Tracy Morgan",
      age: 39,
      is_manager: false,
      start_date: "07-12-2002",
    },
    {
      id: 4,
      name: "Jenna Maroney",
      age: 40,
      is_manager: false,
      start_date: "02-28-1999",
    },
    {
      id: 5,
      name: "Kenneth Parcell",
      age: Infinity,
      is_manager: false,
      start_date: "01-01-1970",
    },
    {
      id: 6,
      name: "Pete Hornberger",
      age: null,
      is_manager: true,
      start_date: "04-01-2000",
    },
    {
      id: 7,
      name: "Frank Rossitano",
      age: 36,
      is_manager: false,
      start_date: null,
    },
    { id: 8, name: null, age: null, is_manager: null, start_date: null },
  ];
  const columns = [
    { accessor: "name", label: "Name" },
    { accessor: "age", label: "Age" },
    {
      accessor: "is_manager",
      label: "Manager",
      format: (value) => (value ? "✔️" : "✖️"),
    },
    { accessor: "start_date", label: "Start Date" },
  ];

  useEffect(() => {}, []);

  // setData([
  //   { column1: "Value 1", column2: "Value 2", column3: "Value 3" },
  //   { column1: "Value 4", column2: "Value 5", column3: "Value 6" },
  //   // Add more data rows as needed
  // ]);
  return (
    <>
      <FileInput />
      <div className="container">
        <h1>My Table</h1>
        <Table rows={rows} columns={columns} />
      </div>
    </>
  );
};

export default Dashboard;
