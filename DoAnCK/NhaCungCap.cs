﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

[Serializable]
public class NhaCungCap : ISerializable
{
    public string id_ncc;
    public string ten_ncc;
    public string dia_chi_ncc;
    public string sdt_ncc;

    public NhaCungCap()
    {

    }
    public NhaCungCap(string id_ncc, string ten_ncc, string sdt_ncc, string dia_chi_ncc)
    {
        this.id_ncc = id_ncc;
        this.ten_ncc = ten_ncc;
        this.sdt_ncc = sdt_ncc;
        this.dia_chi_ncc = dia_chi_ncc;
    }
    public override string ToString()
    {
        return $"{id_ncc,-5} | {ten_ncc,-20} | {sdt_ncc,-20} | {dia_chi_ncc,-20}";
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("id_ncc", id_ncc);
        info.AddValue("ten_ncc", ten_ncc);
        info.AddValue("dia_chi_ncc", dia_chi_ncc);
        info.AddValue("sdt_ncc", sdt_ncc);
    }

    public NhaCungCap(SerializationInfo info, StreamingContext context)
    {
        id_ncc = info.GetString("id_ncc");
        ten_ncc = info.GetString("ten_ncc");
        sdt_ncc = info.GetString("sdt_ncc");
        dia_chi_ncc = info.GetString("dia_chi_ncc");
    }

}