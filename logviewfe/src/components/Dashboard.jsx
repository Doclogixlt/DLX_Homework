import React, { useEffect, useState } from "react";
import FileUpload from "./FileUpload";
import { Table } from "./Table";
import "./styles.css";

const columns2 = [
  { accessor: "deviceVendor", label: "deviceVendor" },
  { accessor: "deviceProduct", label: "deviceProduct" },
  { accessor: "deviceVersion", label: "deviceVersion" },
  { accessor: "signatureId", label: "signatureId" },
  { accessor: "severity", label: "severity" },
  { accessor: "name", label: "name" },
  { accessor: "start", label: "start" },
  { accessor: "rt", label: "rt" },
  { accessor: "msg", label: "msg" },
  { accessor: "shost", label: "shost" },
  { accessor: "smac", label: "smac" },
  { accessor: "dhost", label: "dhost" },
  { accessor: "dmac", label: "dmac" },
  { accessor: "suser", label: "suser" },
  { accessor: "suid", label: "suid" },
  { accessor: "externalId", label: "externalId" },
  { accessor: "cs1Label", label: "cs1Label" },
  { accessor: "cs1", label: "cs1" },
];

const colFilter = {
  deviceVendor: "string",
  deviceProduct: "string",
  deviceVersion: 0,
  signatureId: "string",
  severity: 0,
  name: "string",
  start: "2023-06-21T20:41:12.765Z",
  rt: "string",
  msg: "string",
  shost: "string",
  smac: "string",
  dhost: "string",
  dmac: "string",
  suser: "string",
  suid: "string",
  externalId: 0,
  cs1Label: "string",
  cs1: "string",
};

const rows2 = [
  {
    deviceVendor: "Microsoft",
    deviceProduct: "Windows Vista",
    deviceVersion: 1,
    signatureId: "Microsoft-Windows-Security-Auditing:4624",
    severity: 3,
    name: "An account was successfully logged on.",
    start: "2022-05-29T15:46:44.96+00:00",
    rt: "1653839204.96",
    msg: "This event is generated when a logon session is created. It is generated on the computer that was accessed. The subject fields indicate the account on the local system which requested the logon. This is most commonly a service such as the Server service, or a local process such as Winlogon.exe or Services.exe. The logon type field indicates the kind of logon that occurred. The most common types are 2 (interactive) and 3 (network). The New Logon fields indicate the account for whom the new logon was created, i.e. the account that was logged on. The network fields indicate where a remote logon request originated. Workstation name is not always available and may be left blank in some cases. The impersonation level field indicates the extent to which a process in the logon session can impersonate. The authentication information fields provide detailed information about this specific logon request. - Logon GUID is a unique identifier that can be used to correlate this event with a KDC event. - Transited services indicate which intermediate services have participated in this logon request. - Package name indicates which sub-protocol was used among the NTLM protocols. - Key length indicates the length of the generated session key. This will be 0 if no session key was requested.",
    shost: "LAPTOP-O4EY5H79RR",
    smac: "00:E0:4C:c7:fb:98",
    dhost: "w2016r2004-srv",
    dmac: "78:0C:B8:90:6b:46",
    suser: "LAPTOP-O4EY5H79RR$",
    suid: "0x349980f",
    externalId: 4624,
    cs1Label: "payload",
    cs1: "",
  },
  {
    deviceVendor: "Microsoft",
    deviceProduct: "Windows Vista",
    deviceVersion: 1,
    signatureId: "Microsoft-Windows-Security-Auditing:4624",
    severity: 3,
    name: "An account was successfully logged on.",
    start: "2022-05-29T15:46:44.96+00:00",
    rt: "1653839204.96",
    msg: "This event is generated when a logon session is created. It is generated on the computer that was accessed. The subject fields indicate the account on the local system which requested the logon. This is most commonly a service such as the Server service, or a local process such as Winlogon.exe or Services.exe. The logon type field indicates the kind of logon that occurred. The most common types are 2 (interactive) and 3 (network). The New Logon fields indicate the account for whom the new logon was created, i.e. the account that was logged on. The network fields indicate where a remote logon request originated. Workstation name is not always available and may be left blank in some cases. The impersonation level field indicates the extent to which a process in the logon session can impersonate. The authentication information fields provide detailed information about this specific logon request. - Logon GUID is a unique identifier that can be used to correlate this event with a KDC event. - Transited services indicate which intermediate services have participated in this logon request. - Package name indicates which sub-protocol was used among the NTLM protocols. - Key length indicates the length of the generated session key. This will be 0 if no session key was requested.",
    shost: "LAPTOP-O4EY5H79RR",
    smac: "00:E0:4C:c7:fb:98",
    dhost: "w2016r2004-srv",
    dmac: "78:0C:B8:90:6b:46",
    suser: "LAPTOP-O4EY5H79RR$",
    suid: "0x349980f",
    externalId: 4624,
    cs1Label: "payload",
    cs1: "",
  },
];

const parameters = {
  LogFilter: {
    deviceVendor: null,
    deviceProduct: null,
    deviceVersion: null,
    signatureId: null,
    severity: null,
    name: null,
    start: null,
    rt: null,
    msg: null,
    shost: null,
    smac: null,
    dhost: null,
    dmac: null,
    suser: null,
    suid: null,
    externalId: null,
    cs1Label: null,
    cs1: null,
  },
  Pagination: {
    page: 1,
    perPage: 10,
  },
};

const Dashboard = () => {
  const [rowsf, setRowsF] = useState();
  const token = localStorage.getItem("token");

  useEffect(() => {
    fetch("https://localhost:7025/log/get", {
      method: "POST",
      body: JSON.stringify(parameters),
      headers: {
        Authorization: `Bearer ${token}`,
        "Content-Type": "application/json",
      },
    })
      .then((response) => response.json())
      .then((data) => {
        console.log("data--", data);
        setRowsF(data.logs);
      })
      .catch((error) => {
        console.error(error);
      });
  }, []);

  useEffect(() => {
    console.log("rows chsnged---");
  }, [rowsf]);

  return (
    <div className="wrapper">
      <FileUpload />

      <div className="container">
        <h1>Table 2</h1>
        <Table rows={rowsf} columns={columns2} />
      </div>
    </div>
  );
};

export default Dashboard;
