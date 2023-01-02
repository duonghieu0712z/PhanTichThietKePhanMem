using BusinessLayer.DBAccess;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Models;


namespace BusinessLayer.Functions
{
    public class HRFunctions : BaseFunctions
    {


        private static HRFunctions instance = null;
        public static HRFunctions Instance
        {
            get
            {
                if (instance == null)
                    instance = new HRFunctions();
                return instance;
            }
        }

        public List<POST> Select_All_POST()
        {
            return PostExt.Instance.POST_Select_All();
        }

        public POST Select_POST_ID(int id)
        {
            return PostExt.Instance.POST_Select_ID(id);
        }

        public int InsertNUpdatePOST(POST post)
        {
            return PostExt.Instance.POST_InsertUpdate(post);
        }

        public void DeletePOST(List<String> IDs)
        {
            PostExt.Instance.POST_Delete_IDs(IDs);
        }

        public List<POST> POST_Pagination(string keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            return PostExt.Instance.POST_Find_KeyWord(keyword, PageSize, PageIndex, out TotalRows);
        }

        public List<Information> SelectAll()
        {
            return InformationExt.Instance.Information_Select_All();
        }

        public int InsertUpdateInfo(Information info)
        {
            return InformationExt.Instance.Info_InsertUpdate(info);
        }

        public void DeleteInfo(int id)
        {
            InformationExt.Instance.Info_Delete(id);
        }

        public Information GetInfo_FromID(int id)
        {
            return InformationExt.Instance.Info_Select_ID(id);
        }

        public List<Information> SearchByName(string nameValue)
        {
            //Ghi loc, kiem tra quyen, kiem du lieu co hop le khong?
            return InformationExt.Instance.Info_Select_By("Title", nameValue);
        }

        public List<Information> DeleteAll()
        {
            //Ghi loc, kiem tra quyen, kiem du lieu co hop le khong?
            return InformationExt.Instance.Info_Delete_all();
        }

        public ReflectType GetReflectTypeByID(int id)
        {
            return ReflectTypeExt.Instance.ReflectType_Select_ID(id);
        }

        public List<Reflect> SelectAllReflect()
        {
            //Ghi loc, kiem tra quyen, kiem du lieu co hop le khong?
            return ReflectExt.Instance.Reflect_Select_All();
        }

        public List<Reflect> SearchReflectCriteria(string multiColumn, int pageSize, int pageIndex, out int total)
        {
            return ReflectExt.Instance.Reflect_Find_KeyWord(multiColumn, pageSize, pageIndex, out total);
        }

        public List<ReflectType> SearchReflectTypeByCrieria(string multiColumn, int pageSize, int pageIndex, out int total)
        {
            return ReflectTypeExt.Instance.ReflectType_Find_KeyWord(multiColumn, pageIndex, pageSize, out total);
        }

        public List<ReflectType> SelectAllReflectType()
        {
            //Ghi loc, kiem tra quyen, kiem du lieu co hop le khong?
            return ReflectTypeExt.Instance.ReflectType_Select_All();
        }

        public void AddReflect(object reflect)
        {
            throw new NotImplementedException();
        }

        public int InsertUpdateReflectType(int id, string name)
        {
            ReflectType reflectType;
            reflectType = new ReflectType
            {
                ReflectTypeID = id,
                Name = name,

            };
            return ReflectTypeExt.Instance.ReflectType_InsertUpdate(reflectType);
        }


        public int AddReflect(Reflect reflect)
        {
            return ReflectExt.Instance.Reflect_InsertUpdate(reflect);
        }

        public Reflect FindReflectByID(int id)
        {
            return ReflectExt.Instance.Reflect_Select_ID(id);
        }

        public ReflectType FindReflectTypeByID(int id)
        {
            return ReflectTypeExt.Instance.ReflectType_Select_ID(id);
        }

        public ReflectType SelectReflectTypeByIDs(int id)
        {
            return ReflectTypeExt.Instance.ReflectType_Select_ID(id);
        }

        public void DeleteReflectType(int id)
        {
            ReflectTypeExt.Instance.ReflectType_Delete(id);
        }

        public void DeleteReflectTypeIDs(List<string> ids)
        {
            ReflectTypeExt.Instance.ReflectType_Delete_IDs(ids);
        }

        public void DeleteReflectByID(int id)
        {
            ReflectExt.Instance.Reflect_Delete(id);
        }

        public List<Reflect> Reflect_Pagination(int PageSize, int PageIndex, out int TotalRows)
        {
            return ReflectExt.Instance.Reflect_Pagination(PageSize, PageIndex, out TotalRows);
        }

        public List<ReflectType> Reflect_Type_Pagination(int PageSize, int PageIndex, out int TotalRows)
        {
            return ReflectTypeExt.Instance.ReflectType_Pagination(PageSize, PageIndex, out TotalRows);
        }

        public int Get_Reflect_Total_Row()
        {
            return ReflectExt.Instance.Get_Total_Rows();
        }
        public void DeleteReflectByIDs(List<string> list)
        {
            ReflectExt.Instance.Reflect_Delete_IDs(list);
        }
        public void DeleteReflect(int id)
        {
            ReflectExt.Instance.Reflect_Delete(id);
        }

        public Reflect FindBusByTitle(string tieude)
        {
            return ReflectExt.Instance.Reflect_Select_Title(tieude);
        }
        public List<Reflect> Reflect_Find_KeyWord(int PageSize, int PageIndex, out int TotalRows)
        {
            return ReflectExt.Instance.Reflect_Find_KeyWord("", PageSize, PageIndex, out TotalRows);
        }
        public List<ReflectType> Reflect_Find_Type_KeyWord(int PageSize, int PageIndex, out int TotalRows)
        {
            return ReflectTypeExt.Instance.ReflectType_Find_KeyWord("", PageSize, PageIndex, out TotalRows);
        }

        public ReflectType FindBusTypeByReflectTypeNameAndCarMarker(string Reflecttypename)
        {
            return ReflectTypeExt.Instance.ReflectType_Select_ReflectTypeName(Reflecttypename);
        }

        public void DeleteListDocumentType(List<string> list)
        {
            DocumentTypeExt.Instance.Delete_IDs(list);
        }

        public int InsertUpdate_DocumentType(DocumentType obj)
        {
           return DocumentTypeExt.Instance.InsertUpdate(obj);
        }

        public int InsertUpdate_Document(Document obj)
        {
            return DocumentExt.Instance.InsertUpdate(obj);
        }


        public DocumentType EditDocument_ByID(int idEdit)
        {
            return DocumentTypeExt.Instance.Select_ID(idEdit);
        }

        public Document EditDocumentUI_ByID(int idEdit)
        {
            return DocumentExt.Instance.Select_ID(idEdit);
        }

        public List<DocumentType> FindDocumentTypeByKeyWord(string value, int pagesize, int index, out int rows)
        {
            return DocumentTypeExt.Instance.Find_KeyWord(value, pagesize, index, out rows);
        }

        public List<Document> FindDocumentByKeyWord(string value, int pagesize, int index, out int rows)
        {
            return DocumentExt.Instance.Find_KeyWord(value, pagesize, index, out rows);
        }

        public Document SelectDocumentId(int id)
        {
            return DocumentExt.Instance.Select_ID(id);
        }

        public List<Document> FindDocumentByPage(int pagesize, int pindex, out int rows)
        {
            return DocumentExt.Instance.Find_DocumentAll(pagesize, pindex, out rows);
        }

        public List<Document> Load_DocumentFindType(string loai,int pagesize, int pindex, out int rows)
        {
            return DocumentExt.Instance.Find_DocumentType(loai ,pagesize, pindex, out rows);
        }

        public List<DocumentType> SelectAll_DocumentType()
        {
            return DocumentTypeExt.Instance.Select_All();
        }

        public List<HandlingViolation> SelectAllHand()
        {
            return handlingViolationsExt.Instance.HandlingViolation_Select_All();
        }
        public List<String> SelectTitle()
        {
            return handlingViolationsExt.Instance.HandlingViolation_Select_All().Select(x => x.Title).ToList();
        }
        public int InsertUpdateInfo(HandlingViolation info)
        {
            return handlingViolationsExt.Instance.HandlingViolations_InsertUpdate(info);
        }

        public void DeleteInfoHand(int id)
        {
            handlingViolationsExt.Instance.HandlingViotions_Delete(id);
        }

        public HandlingViolation GetInfo_FromIDHand(int id)
        {
            return handlingViolationsExt.Instance.HandlingViolation_Select_ID(id);
        }

        public List<HandlingViolation> SearchByNameHand(string nameValue)
        {
            //Ghi loc, kiem tra quyen, kiem du lieu co hop le khong?
            return handlingViolationsExt.Instance.HandlingViolation_Select_By("Title", nameValue);
        }

    }
}
