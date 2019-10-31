using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PASA
{
    //TTAA
    public class DataStruct
    {
        public enum CustomerStatus
        {
            CREATED = 10
        };

        public enum UserStatus
        {
            Registered = 10
        };
        public enum UserType
        {
            Staff = 1,
            Customer=2
        };
        public enum NICStatus
        {
            Pending = 1,
            Approved = 2,
            Rejected=3
        };
        public enum ProductAutoBid
        {
            Pending = 1,
            Used = 2
        };
        public enum ProductStatus
        {
            Pending = 1,
            Approved = 2,
            Rejected = 3,
            BuyNowSold=4,
            Expired=5,
            AuctionCancelled=6
        };
        public enum MsgStatus
        {
            Pending = 1,
            Read = 2
        };
        public enum UserRole
        {
            Administrator = 1,
            Customer = 5
        };
        public enum SellerStatus
        {
            IntialRegistered = 10,
            SellerRegistered = 20,
            SellerApproved = 30
        };
        public enum BidderStatus
        {
            InitialRegistered = 10,
            BidderRegistered = 20,
            BidderApproved = 30
        };
        public enum CartProductType
        {
            Product = 1,
            Candle = 2,
            Size = 3

        }
        public enum TrnsactionRating
        {
            Pending = 10,
            Answered = 20

        }
        public enum SellerRatingStatus
        {
            Positive = 1,
            Negative = 2,
            Neutral=3

        }
        public enum BookingStatus
        {
            Pending = 10,
            Accepted=20,
            Declined=30,
            Tour_Started=40,
            Tour_Ended=50,
            No_Driver=60
        };
        public enum CurrencyType
        {
            Dollar = 1,
            LKR = 2

        }
        public enum SessionType
        {
            Bidding = 1,
            WatchList = 2,
            AddToCart=3,
            BuyNow=4

        }
        public enum OrderStatus
        {
            Confirmed = 10
          
        };
        public enum DriverStatus
        {
            Created = 10,
            Online = 30,
            Offline = 40,
            On_Hire = 50
        };
        public enum DriverBookingStatus
        {
            Pending = 10,
            Accepted = 30,
            Rejected = 40,
                    };
        public enum VehicleDriverTrnStatus
        {
            Active = 10,
            Inactive = 20
         
        };
        public enum BidFromPage
        {
            ProdDetail = 1,
            Inactive = 2

        };
      
    }
}