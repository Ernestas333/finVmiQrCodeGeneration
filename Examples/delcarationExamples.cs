using finVmiQrCodeGeneration.WebReference; 

namespace finVmiQrCodeGeneration
{
	public class delcarationExamples
	{
		// 2.0 punkto pvz
		public static submitDeclarationRequest exampleRequest()
		{
			return new submitDeclarationRequest()
			{
				Declaration = new TFDeclaration_Type()
				{
					DocHeader = new DocHeader_Type()
					{
						DocId = "SOME-DOC-ID",
						DocCorrNo = "99",
						CompletionDate = new System.DateTime(2021, 12, 08)
					},

					Customer = new Customer_Type()
					{
						FirstName = "John",
						LastName = "Doe",
						IdentityDocument = new IdentityDocument_Type()
						{
							DocNo = new IdDocNo_Type()
							{
								Value = "1234567890"
							}
						},
						PersonIn = new PersonIn_Type()
						{
							Value = "1234567890"
						}
					},
					SalesDocument = new SalesDocument_Type[] {
						new SalesDocument_Type() {
							Goods = new GoodsItem_Type[] {
								new GoodsItem_Type() {
									SequenceNo = "1",
									Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit 1",
									Quantity = 10,
									Item = "NAR",
									ItemElementName = ItemChoiceType.UnitOfMeasureCode,
									TotalAmount = 56.5m
								},
								new GoodsItem_Type() {
									SequenceNo = "2",
									Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit 2",
									Quantity = 10.5m,
									Item = "Other unit of measure",
									ItemElementName = ItemChoiceType.UnitOfMeasureOther,
									TotalAmount = 57.5m
								},
								new GoodsItem_Type() {
									SequenceNo = "3",
									Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit 3",
									Quantity = 0.5m,
									Item = "Other unit of measure",
									ItemElementName = ItemChoiceType.UnitOfMeasureOther,
									TotalAmount = 58.5m
								}
							}
						}
					}
				}
			};
		}

		//iš 3.3 gauti duomenys sudėti į request
		public static submitDeclarationRequest hashedRequest()
		{
			return new submitDeclarationRequest()
			{
				Declaration = new TFDeclaration_Type()
				{
					DocHeader = new DocHeader_Type()
					{
						DocId = "SOME-DOC-ID",
						DocCorrNo = "99",
						CompletionDate = new System.DateTime(2021, 12, 08)
					},

					Customer = new Customer_Type()
					{
						FirstName = "John",
						LastName = "Doe",
						IdentityDocument = new IdentityDocument_Type()
						{
							DocNo = new IdDocNo_Type()
							{
								Value = "1234567890"
							}
						},
						PersonIn = new PersonIn_Type()
						{
							Value = "1234567890"
						}
					},
					SalesDocument = new SalesDocument_Type[] {
						new SalesDocument_Type() {
							Goods = new GoodsItem_Type[] {
								new GoodsItem_Type() {
									SequenceNo = "1",
									Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit 1",
									Quantity = 10,
									Item = "NAR",
									ItemElementName = ItemChoiceType.UnitOfMeasureCode,
									TotalAmount = 56.5m
								},
								new GoodsItem_Type() {
									SequenceNo = "2",
									Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit 2",
									Quantity = 10,
									Item = "Other unit of measure",
									ItemElementName = ItemChoiceType.UnitOfMeasureOther,
									TotalAmount = 57.5m
								},
								new GoodsItem_Type() {
									SequenceNo = "3",
									Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit 3",
									Quantity = 10,
									Item = "Other unit of measure",
									ItemElementName = ItemChoiceType.UnitOfMeasureOther,
									TotalAmount = 58.5m
								}
							}
						}
					}
				}
			};
		}
	}
}
