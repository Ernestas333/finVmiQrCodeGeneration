using finVmiQrCodeGeneration.WebReference; 
using System.Linq; 

namespace finVmiQrCodeGeneration
{
    public class InputDataStructure
    {
        public docHeader docHeader;
        public customer customer;
        public goods[] goods;

        public InputDataStructure(submitDeclarationRequest decl)
        {
            docHeader = new docHeader(decl.Declaration.DocHeader);
            customer = new customer(decl.Declaration.Customer);

            goods = decl.Declaration.SalesDocument[0].Goods.Select(x => { return new goods(x); }).ToArray();
        }
    }

    public class docHeader
    {
        public string docId;
        public long docCorrNo;
        public string completionDate;

        public docHeader(DocHeader_Type header)
        {
            docId = header.DocId;
            docCorrNo = long.Parse(header.DocCorrNo);
            completionDate = header.CompletionDate.ToString("yyyy-MM-dd");
        }
    }

    public class customer
    {
        public string firstName;
        public string lastName;
        public string identityDocumentNo;

        public customer(Customer_Type customer)
        {
            firstName = customer.FirstName;
            lastName = customer.LastName;
            identityDocumentNo = customer.IdentityDocument.DocNo.Value;
        }
    }

    public class goods
    {
        public long sequenceNo;
        public string description;
        public decimal quantity;
        public string unitOfMeasureCode;
        public string unitOfMeasureOther;
        public decimal totalAmount;

        public goods(GoodsItem_Type good)
        {
            sequenceNo = long.Parse(good.SequenceNo);
            description = good.Description;
            quantity = good.Quantity;

            if (good.ItemElementName == ItemChoiceType.UnitOfMeasureCode)
            {
                unitOfMeasureCode = good.Item;
                unitOfMeasureOther = null;
            }
            else
            {
                unitOfMeasureCode = null;
                unitOfMeasureOther = good.Item;
            }

            totalAmount = good.TotalAmount;
        }
    }
}
