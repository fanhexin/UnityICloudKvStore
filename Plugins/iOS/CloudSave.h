#import <Foundation/Foundation.h>

@interface CloudSave : NSObject

- (BOOL) setDevString: (NSString*) key : (NSString*) value;
- (const char*) getDevString: (NSString*) key;
- (BOOL) deleteDevString: (NSString*) key;
- (void) updateFromiCloud:(NSNotification*) notification;
- (char *) makeStringCopy: (const char *) string;
- (NSString *) createNSString: (const char *) string;

extern void UnitySendMessage(const char *, const char *, const char *);

@end
