# Async-Inn
##  Lab: 11 - Relational Databases

in this system, i have 5 table 
## Hotel

## Hotel  ((Async Inn))
the Attributes of hotel is
1. locations :
 - a name.
  - city.
  - state.
  - address .
  - phone number.

## For example : 

| Async Inn     | DATA |
| ----------- | ----------- |
| name      | Async Inn Irbid       |
| city   | Irbid     |
| state      | Irbid       |
| address   | Irbid-Al Quds street        |
| phone number      | 07888655022       |

=================================

## Room
the Attributes of Room is
1.  Name . 
  
2. Layout .


## For example : 

| Async Inn Irbid     | DATA |
| ----------- | ----------- |
| name      | Async Inn Irbid       |
| Layout   | stido     |
| Layout   | 1bedroom     |


## HotelRoom
the Attributes of HotelRoom is
1. Room Number the number in hotel
3. Rate the rate of each Room
4. pet Friendly: if allow to anmil live or not

## Amenities
Features in the room
## RoomAmenities
Features in each room alone

![](/img/120.png)


=======================================================================================================
## Lab: 12 - Intro to Entity Framework

in tis lap i make my first app in Asp core and this my resulets


### Hotel

![](/img/Hotel.png)

### Room

![](/img/Room.png)

###  Amenities

![](/img/Amenities.png)

==================================================================================
## Lab 13: Dependency Injection & Repository Design Pattern
1. in this lap i Using Dependency Injection,refactor your Hotels, Rooms, and Amenities Controllers to depend on an interface rather than the DbContext
2. Build an interface for each of the controllers that contain the required method signatures to all for CRUD operations to the database directly.
3. Update each of the controllers to inject the interface rather than the DBContext.
4. Create a service for each of the controllers that implement the appropriate interface. Build out the logic to satisfy the interface by making the appropriate calls to the db for each action.
5.  Update your Controller to use the appropriate method from the interface rather than the DBContext directly.
6. Confirm in POSTMAN that your controllers are returning the same logic as they did in Lab 12.

# all this image after the Injection
### Hotel

![](/img/getHotel.png)

### Room

![](/img/getRoom.png)

###  Amenities

![](/img/getAmenities.png)



## Test Post
![](/img/postRoom.png)