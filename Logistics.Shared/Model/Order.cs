﻿
using Logistics.Shared.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistics.Shared.Model
{
    public class Order
    {
        [DisplayName("订单号")]
        [Column(TypeName = "varchar(64)")]
        public string OrderId { get; set; }
        [DisplayName("订单账号")]
        public State OrderState { get; set; } = State.None;
        [DisplayName("收件人")]
        public string Recipient { get; set; }
        [DisplayName("收件人电话")]
        public string RecipientPhone { get; set; }
        [DisplayName("寄件人")]
        public string Sender { get; set; }
        [DisplayName("寄件人电话")]
        public string SenderPhone { get; set; }
        [DisplayName("寄件人地址")]
        public string SenderCity { get; set; }
        [DisplayName("收件人地址")]
        public string RecipientCity { get; set;}
        [DisplayName("订单详情")]
        public string OrderInfo { get; set; }
        [DisplayName("费用")]
        public decimal Cost { get; set; } = decimal.Zero;

        public Order()
        {
            
        }

        public Order(string orderId, string recipient, string recipientPhone, string sender, string senderCity, string senderPhone, string recipientCity, string orderInfo)
        {
            this.OrderId = orderId;
            this.Recipient = recipient;
            this.RecipientPhone = recipientPhone;
            this.Sender = sender;
            this.SenderCity = senderCity;
            this.SenderPhone = senderPhone;
            this.RecipientCity = recipientCity;
            this.OrderInfo = orderInfo;
        }
    }
}
