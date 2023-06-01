import pymysql
import datetime
from config import host, user, password, db_name

date_time = datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")

try:
    connection = pymysql.connect(
        host=host,
        port=3306,
        user=user,
        password=password,
        database=db_name,
        cursorclass=pymysql.cursors.DictCursor
    )
    print("Successfully connected...")
    print("#" * 20)

    try:

        #create table
        try:
            for ite in range(1, 6):
                with connection.cursor() as cursor:
                    create_table_query = f"CREATE TABLE `table_{ite}`(ID int AUTO_INCREMENT," \
                                         "DATE_TIME_CHANGE varchar(32)," \
                                         "COMM varchar(32), PRIMARY KEY (ID));"
                    cursor.execute(create_table_query)
                    print(f"Table_{ite} created successfully")
        except Exception as ex:
            print("Table not created...")
            print(ex)

        #fill tables(10000 data)
        try:
            with connection.cursor() as cursor:
                for i in range(1, 6):
                    for j in range(10000):
                        insert_query = f"INSERT INTO `table_{i}` (DATE_TIME_CHANGE, COMM) VALUES ('{date_time}', 'asdeqw');"
                        cursor.execute(insert_query)
                    connection.commit()
                print("Filled successfully")
        except Exception as ex:
            print("Filled refused....")
            print(ex)

    except Exception as ex:
        print("Query refused....")
        print(ex)

    finally:
        connection.close()
except Exception as ex:
    print("Connection refused....")
    print(ex)
