﻿using DoAnCK;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class KhoHang
{
    string ten_kho;
    public List<HangHoa> ds_hang_hoa = new List<HangHoa>();
    public List<NhanVien> ds_nhan_vien = new List<NhanVien>();
    public List<CuaHang> ds_cua_hang = new List<CuaHang>();
    public List<NhaCungCap> ds_ncc = new List<NhaCungCap>();
    public List<HoaDonNhap> ds_hoa_don_nhap = new List<HoaDonNhap>();
    public List<HoaDonXuat> ds_hoa_don_xuat = new List<HoaDonXuat>();
    public void LuuDanhSachNCC()
    {
        string filePath = "Resources/nha_cung_cap.dat";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<NhaCungCap>));
            serializer.Serialize(writer, ds_ncc);
        }
    }
    public bool kha_dung(HangHoa hh)
    {
        HangHoa hh_kho = ds_hang_hoa.Find(x => x.id == hh.id);
        if (hh.so_luong >= hh_kho.so_luong)
        {
            return true;
        }
        return false;
    }

    public void capnhatkho(List<HangHoa> ds_hh, bool nhap_xuat)
    {
        if (nhap_xuat)
        {
            foreach (HangHoa hanghoa in ds_hh)
            {
                HangHoa hh_kho = ds_hang_hoa.Find(x => x.id == hanghoa.id);
                hh_kho.so_luong += hanghoa.so_luong;
            }
        }
        else
        {
            foreach (HangHoa hanghoa in ds_hh)
            {
                HangHoa hh_kho = ds_hang_hoa.Find(x => x.id == hanghoa.id);
                hh_kho.so_luong -= hanghoa.so_luong;
            }
        }
    }

    public void them_hoa_don_nhap(HoaDonNhap hd_nhap)
    {
        ds_hoa_don_nhap.Add(hd_nhap);
    }

    public void them_hoa_don_xuat(HoaDonXuat hd_xuat)
    {
        ds_hoa_don_xuat.Add(hd_xuat);
    }
}