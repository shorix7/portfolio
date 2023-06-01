import threading
import pymysql
import pymysqlpool
import datetime
from config import host, user, password, db_name

pool = pymysqlpool.ConnectionPool(
    host=host,
    port=3306,
    user=user,
    password=password,
    database=db_name,
    autocommit=True,
    charset='utf8mb4',
    cursorclass=pymysql.cursors.DictCursor
)

def update_1(date_now):
    while True:
        try:
            with pool.get_connection() as connection:
                with connection.cursor() as cursor:
                    update_query = f"UPDATE `table_1` SET DATE_TIME_CHANGE = '{date_now}';"
                    cursor.execute(update_query)
            break
        except Exception as ex:
            print("Update refused....")
            print(ex)

def update_2(date_now):
    while True:
        try:
            with pool.get_connection() as connection:
                with connection.cursor() as cursor:
                    update_query = f"UPDATE `table_2` SET DATE_TIME_CHANGE = '{date_now}';"
                    cursor.execute(update_query)
            break
        except Exception as ex:
            print("Update refused....")
            print(ex)

def update_3(date_now):
    while True:
        try:
            with pool.get_connection() as connection:
                with connection.cursor() as cursor:
                    update_query = f"UPDATE `table_3` SET DATE_TIME_CHANGE = '{date_now}';"
                    cursor.execute(update_query)
            break
        except Exception as ex:
            print("Update refused....")
            print(ex)

def update_4(date_now):
    while True:
        try:
            with pool.get_connection() as connection:
                with connection.cursor() as cursor:
                    update_query = f"UPDATE `table_4` SET DATE_TIME_CHANGE = '{date_now}';"
                    cursor.execute(update_query)
            break
        except Exception as ex:
            print("Update refused....")
            print(ex)

def update_5(date_now):
    while True:
        try:
            with pool.get_connection() as connection:
                with connection.cursor() as cursor:
                    update_query = f"UPDATE `table_5` SET DATE_TIME_CHANGE = '{date_now}';"
                    cursor.execute(update_query)
            break
        except Exception as ex:
            print("Update refused....")
            print(ex)


try:
    print("Successfully connected...")
    print("#" * 20)

    thread_1 = threading.Thread(target=update_1,
                                args=(datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S"),),
                                name="thr-1")
    thread_2 = threading.Thread(target=update_2,
                                args=(datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S"),),
                                name="thr-2")
    thread_3 = threading.Thread(target=update_3,
                                args=(datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S"),),
                                name="thr-3")
    thread_4 = threading.Thread(target=update_4,
                                args=(datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S"),),
                                name="thr-4")
    thread_5 = threading.Thread(target=update_5,
                                args=(datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S"),),
                                name="thr-5")

    thread_1.start()
    thread_2.start()
    thread_3.start()
    thread_4.start()
    thread_5.start()

    thread_1.join()
    thread_2.join()
    thread_3.join()
    thread_4.join()
    thread_5.join()

except Exception as ex:
    print("Connection refused....")
    print(ex)


